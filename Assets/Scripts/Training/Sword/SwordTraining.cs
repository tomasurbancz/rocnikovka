using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwordTraining : MonoBehaviour
{
    // Start is called before the first frame update
    public Image Apple1;
    public Image Apple2;
    public Image Apple3;
    public Image Star;

    public Image Apple1Collision;
    public Image Apple2Collision;
    public Image Apple3Collision;
    public Image CharacterCollision;
    public Image StarCollision;
    public Image StarDespawnCollision;

    public Image Character;
    private Animator _animator;
        
    private List<SwordTrainingObject> _trainingObjects = new List<SwordTrainingObject>();
    private int _maxTrainingObjects = 5;
    private float _objectSpawnCooldown = 0.25f;

    public Slider Slider;
    public TMP_Text Combo;
    private ScoreSlider _scoreSlider;
    private int _score;
    
    private float _speed = 2.0f;
    
    private KeyCode _lastKey = KeyCode.None;
    private bool _isNewKey = false;
    private float _animationTime = 0.15f;

    private Missions _missions;
    public TMP_Text MissionHeaderText;
    public TMP_Text MissionInfoText;

    void Start()
    {
        _missions = new Missions(new SwordTrainingMissions(), 0, MissionHeaderText, MissionInfoText, new MissionRewarder(MissionRewarder.Type.Sword));
        _scoreSlider = new ScoreSlider(Slider, Combo, 0, 10);
        _animator = Character.GetComponent<Animator>();
    }

    private void SpawnNewObject()
    {
        int random = Random.Range(0, 7);
        if(random <= 1)
            _trainingObjects.Add(SwordTrainingObject.Create(Apple1, Apple1Collision, (int) KeyCode.W, SwordTrainingObject.TrainingObjectType.Apple));
        else if (random <= 3)
            _trainingObjects.Add(SwordTrainingObject.Create(Apple2, Apple2Collision, (int)KeyCode.D, SwordTrainingObject.TrainingObjectType.Apple));
        else if (random <= 5)
            _trainingObjects.Add(SwordTrainingObject.Create(Apple3, Apple3Collision, (int)KeyCode.S, SwordTrainingObject.TrainingObjectType.Apple));
        else
            _trainingObjects.Add(SwordTrainingObject.Create(Star, StarCollision, (int)KeyCode.A, SwordTrainingObject.TrainingObjectType.Star));
    }

    private void UpdateObjectLocation()
    {
        foreach(SwordTrainingObject trainingObject in _trainingObjects)
        {
            if (trainingObject.TrainingObject.Equals(SwordTrainingObject.TrainingObjectType.Apple))
                trainingObject.Image.transform.position = new Vector2(trainingObject.Image.transform.position.x - (_speed * Time.deltaTime), trainingObject.Image.transform.position.y);
            else
                trainingObject.Image.transform.position = new Vector2(trainingObject.Image.transform.position.x, trainingObject.Image.transform.position.y - (_speed * Time.deltaTime));
        }
    }

    private void CheckForAnimations()
    {
        string animationName = "";
        if (Input.GetKeyDown(_lastKey) && _isNewKey)
        {
            if (_lastKey == KeyCode.A)
            {
                animationName = "Player_Left";
            }
            _isNewKey = false;
            _animationTime = 0.15f;
        }
        if (!animationName.Equals("") || _animationTime < 0)
        {
            Debug.Log("NEW ANIMATION " + "STAND " + animationName);
            _animator.Play("Player_Stand", 0, 0f);
            _animationTime = 0.5f;
        }
        if (!animationName.Equals(""))
        {
            //Animator.Play(animationName, 0, 0f);
        }
    }

    private void CheckForCollision()
    {
        CheckForAnimations();
        List<SwordTrainingObject> trainingObjectsCopy = new List<SwordTrainingObject>(_trainingObjects);
        foreach (SwordTrainingObject trainingObject in trainingObjectsCopy)
        {
            if (AreImagesOverlapping(trainingObject.Image, CharacterCollision))
            {
                _trainingObjects.Remove(trainingObject);
                Destroy(trainingObject.Image);
                Destroy(trainingObject);
                StartNewGame();
                Debug.Log("Collision with character");
            }
            else if (AreImagesOverlapping(trainingObject.Image, StarDespawnCollision))
            {
                _trainingObjects.Remove(trainingObject);
                Destroy(trainingObject.Image);
                Destroy(trainingObject);
                Debug.Log("Star despawning");
            }
            else if (AreImagesOverlapping(trainingObject.Image, trainingObject.Collision))
            {
                if (Input.GetKeyDown(_lastKey))
                {
                    if ((int)_lastKey == trainingObject.CollisionKey)
                    {
                        _trainingObjects.Remove(trainingObject);
                        Destroy(trainingObject.Image);
                        Destroy(trainingObject);
                        if (trainingObject.TrainingObject.Equals(SwordTrainingObject.TrainingObjectType.Apple))
                        {
                            _score++;
                            _missions.UpdateMission(MissionType.APPLES, 1);
                        }
                        else _score += 5;
                        _missions.UpdateMission(MissionType.SCORE, _score, true);
                        UpdateScore();
                        Debug.Log("Collision with apple");
                    }
                }
            }
        }
    }

    private bool AreImagesOverlapping(Image img1, Image img2)
    {
        RectTransform rect1 = img1.rectTransform;
        RectTransform rect2 = img2.rectTransform;

        return RectOverlaps(rect1, rect2);
    }

    private bool RectOverlaps(RectTransform rect1, RectTransform rect2)
    {
        Vector3[] corners1 = new Vector3[4];
        Vector3[] corners2 = new Vector3[4];

        rect1.GetWorldCorners(corners1);
        rect2.GetWorldCorners(corners2);

        Rect r1 = new Rect(corners1[0].x, corners1[0].y, corners1[2].x - corners1[0].x, corners1[2].y - corners1[0].y);
        Rect r2 = new Rect(corners2[0].x, corners2[0].y, corners2[2].x - corners2[0].x, corners2[2].y - corners2[0].y);

        return r1.Overlaps(r2);
    }

    private void CheckForKeys()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    _isNewKey = true;
                    _lastKey = key;
                    break;
                }
            }
        }
    }

    private void StartNewGame()
    {
        _score = 0;
        UpdateScore();
        _speed = 2f;
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
        if (_scoreSlider.CompletedCurrentGoal)
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
        if(_trainingObjects.Count < _maxTrainingObjects && _objectSpawnCooldown <= 0)
        {
            SpawnNewObject();
            _objectSpawnCooldown = 0.25f;
        }
        _objectSpawnCooldown -= Time.deltaTime;
        _animationTime -= Time.deltaTime;
        ChangeSpeed();
        CheckForKeys();
        UpdateObjectLocation();
        CheckForCollision();
    }
}
