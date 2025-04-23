using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArmorTraining : MonoBehaviour
{
    public Image Apple;
    public Image Star;

    public Image CharacterCollision;

    public Image Armor;

    private List<ArmorTrainingObject> _trainingObjects = new List<ArmorTrainingObject>();
    private int _maxTrainingObjects = 5;
    private float _objectSpawnCooldown = 0.25f;

    public Slider Slider;
    public TMP_Text Combo;
    private ScoreSlider _scoreSlider;
    private int _score;

    private float _speed = 2f;

    private Missions _missions;
    public TMP_Text MissionHeaderText;
    public TMP_Text MissionInfoText;

    // Start is called before the first frame update
    void Start()
    {
        _missions = new Missions(new ArmorMissions(), 0, MissionHeaderText, MissionInfoText, new MissionRewarder(MissionRewarder.Type.Armor));
        _scoreSlider = new ScoreSlider(Slider, Combo, 0, 10);
    }

    private void SpawnNewObject()
    {
        int random = Random.Range(0, 4);
        Vector2 location = GetRandomLocation();
        Vector2 direction = CalculateDirection(location);
        if(random == 0)
        {
            _trainingObjects.Add(ArmorTrainingObject.Create(Star, ArmorTrainingObject.TrainingObjectType.Star, location, direction));
        }
        else
        {
            _trainingObjects.Add(ArmorTrainingObject.Create(Apple, ArmorTrainingObject.TrainingObjectType.Apple, location, direction));
        }

    }

    private Vector2 CalculateDirection(Vector2 location)
    {
        return new Vector2(-location.x, -location.y);
    }

    private Vector2 GetRandomLocation() {
        int random = Random.Range(0, 4);
        int offsetX = 1100;
        int offsetY = 680;
        int randomX = Random.Range(0, offsetX*2) - offsetX;
        int randomY = Random.Range(0, offsetY*2) - offsetY;
        if (random == 0)
            return new Vector2(10, (float)(randomY) / offsetY * 10f);
        else if (random == 1)
            return new Vector2(-10, (float) (randomY) /offsetY * 10f);
        else if (random == 2)
            return new Vector2((float) (randomX) /offsetX*10f, 10);
        else
            return new Vector2((float) (randomX) /offsetX*10f, -10);
    }

    private void UpdateObjectLocation()
    {
        foreach (ArmorTrainingObject trainingObject in _trainingObjects)
        {
            trainingObject.Image.transform.position = new Vector2(trainingObject.Image.transform.position.x + (trainingObject.Direction.x * Time.deltaTime * _speed/10), trainingObject.Image.transform.position.y + (trainingObject.Direction.y * Time.deltaTime * _speed/10));
        }
    }

    private void CheckForCollision()
    {
        List<ArmorTrainingObject> trainingObjectsCopy = new List<ArmorTrainingObject>(_trainingObjects);
        foreach (ArmorTrainingObject trainingObject in trainingObjectsCopy)
        {
            if (AreImagesOverlapping(trainingObject.Image, CharacterCollision))
            {
                _trainingObjects.Remove(trainingObject);
                Destroy(trainingObject.Image);
                Destroy(trainingObject);
                if (trainingObject.TrainingObject.Equals(ArmorTrainingObject.TrainingObjectType.Apple))
                    StartNewGame();
                else
                {
                    _score += 5;
                    _missions.UpdateMission(MissionType.STARS, 1);
                    _missions.UpdateMission(MissionType.SCORE, _score, true);
                    UpdateScore();
                }
            }
            else if (AreImagesOverlapping(trainingObject.Image, Armor))
            {
                _trainingObjects.Remove(trainingObject);
                Destroy(trainingObject.Image);
                Destroy(trainingObject);
                if (trainingObject.TrainingObject.Equals(ArmorTrainingObject.TrainingObjectType.Apple))
                {
                    _score++;
                    _missions.UpdateMission(MissionType.APPLES, 1);
                    _missions.UpdateMission(MissionType.SCORE, _score, true);
                }
                UpdateScore();
            }
        }
    }

    private bool AreImagesOverlapping(Image img1, Image img2)
    {
        RectTransform rect1 = img1.rectTransform;
        RectTransform rect2 = img2.rectTransform;

        Vector3[] corners1 = new Vector3[4];
        Vector3[] corners2 = new Vector3[4];

        rect1.GetWorldCorners(corners1);
        rect2.GetWorldCorners(corners2);

        return ArePolygonsOverlapping(corners1, corners2);
    }

    private bool ArePolygonsOverlapping(Vector3[] poly1, Vector3[] poly2)
    {
        Vector2[] axes = new Vector2[]
        {
        GetEdgeNormal(poly1[0], poly1[1]),
        GetEdgeNormal(poly1[1], poly1[2]),
        GetEdgeNormal(poly2[0], poly2[1]),
        GetEdgeNormal(poly2[1], poly2[2])
        };

        foreach (Vector2 axis in axes)
        {
            if (!OverlapsOnAxis(axis, poly1, poly2))
            {
                return false; // Oddìlitelné => žádná kolize
            }
        }
        return true; // Všechny osy se pøekrývají => kolize existuje
    }

    private Vector2 GetEdgeNormal(Vector3 p1, Vector3 p2)
    {
        Vector2 edge = (p2 - p1).normalized;
        return new Vector2(-edge.y, edge.x); // Normála (kolmý vektor)
    }

    private bool OverlapsOnAxis(Vector2 axis, Vector3[] poly1, Vector3[] poly2)
    {
        float min1, max1, min2, max2;
        ProjectPolygon(axis, poly1, out min1, out max1);
        ProjectPolygon(axis, poly2, out min2, out max2);

        return max1 >= min2 && max2 >= min1; // Pøekryv
    }

    private void ProjectPolygon(Vector2 axis, Vector3[] poly, out float min, out float max)
    {
        min = max = Vector2.Dot(axis, poly[0]);
        for (int i = 1; i < poly.Length; i++)
        {
            float projection = Vector2.Dot(axis, poly[i]);
            if (projection < min) min = projection;
            if (projection > max) max = projection;
        }
    }

    private void StartNewGame()
    {
        _score = 0;
        _speed = 1f;
        UpdateScore();

        _missions.ResetIfNotType(MissionType.STARS);
    }

    private void ChangeSpeed()
    {
        int mult = 1 + (_score / 5);
        int maxTrainingObjects = 1 + (_score / 15);
        _speed = 2.0f + (0.2f * mult);
        _maxTrainingObjects = maxTrainingObjects;
    }

    private void UpdateScore()
    {
        _scoreSlider.UpdateProgress(_score);
        if(_scoreSlider.CompletedCurrentGoal)
        {
            _scoreSlider.ChangeGoal(10);
            Account account = Account.GetCurrentAccount();
            account.AccountStats.Hp += 7;
            account.SaveData();
            _scoreSlider.UpdateProgress(_score);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_trainingObjects.Count < _maxTrainingObjects && _objectSpawnCooldown <= 0)
        {
            SpawnNewObject();
            _objectSpawnCooldown = 0.25f;
        }
        _objectSpawnCooldown -= Time.deltaTime;
        ChangeSpeed();
        UpdateObjectLocation();
        CheckForCollision();
    }
}
