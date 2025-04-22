using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwordTraining : MonoBehaviour
{
    // Start is called before the first frame update
    public Image _apple1;
    public Image _apple2;
    public Image _apple3;
    public Image _star;

    public Image _apple1Collision;
    public Image _apple2Collision;
    public Image _apple3Collision;
    public Image _characterCollision;
    public Image _starCollision;
    public Image _starDespawnCollision;

    public Image _character;
    private Animator Animator;
        
    private List<SwordTrainingObject> _trainingObjects = new List<SwordTrainingObject>();
    private int _maxTrainingObjects = 5;
    private float _objectSpawnCooldown = 0.25f;

    public TMP_Text _scoreText;
    private int _score;
    
    private float _speed = 2.0f;
    
    private KeyCode _lastKey = KeyCode.None;
    private bool IsNewKey = false;
    private float AnimationTime = 0.15f;

    void Start()
    {
        Animator = _character.GetComponent<Animator>();
    }

    private void SpawnNewObject()
    {
        int random = Random.Range(0, 7);
        if(random <= 1)
            _trainingObjects.Add(SwordTrainingObject.Create(_apple1, _apple1Collision, (int) KeyCode.W, SwordTrainingObject.TrainingObjectType.Apple));
        else if (random <= 3)
            _trainingObjects.Add(SwordTrainingObject.Create(_apple2, _apple2Collision, (int)KeyCode.D, SwordTrainingObject.TrainingObjectType.Apple));
        else if (random <= 5)
            _trainingObjects.Add(SwordTrainingObject.Create(_apple3, _apple3Collision, (int)KeyCode.S, SwordTrainingObject.TrainingObjectType.Apple));
        else
            _trainingObjects.Add(SwordTrainingObject.Create(_star, _starCollision, (int)KeyCode.A, SwordTrainingObject.TrainingObjectType.Star));
    }

    private void UpdateObjectLocation()
    {
        foreach(SwordTrainingObject trainingObject in _trainingObjects)
        {
            if (trainingObject._trainingObjectType.Equals(SwordTrainingObject.TrainingObjectType.Apple))
                trainingObject._image.transform.position = new Vector2(trainingObject._image.transform.position.x - (_speed * Time.deltaTime), trainingObject._image.transform.position.y);
            else
                trainingObject._image.transform.position = new Vector2(trainingObject._image.transform.position.x, trainingObject._image.transform.position.y - (_speed * Time.deltaTime));
        }
    }

    private void CheckForAnimations()
    {
        string animationName = "";
        if (Input.GetKeyDown(_lastKey) && IsNewKey)
        {
            if (_lastKey == KeyCode.A)
            {
                animationName = "Player_Left";
            }
            IsNewKey = false;
            AnimationTime = 0.15f;
        }
        if (!animationName.Equals("") || AnimationTime < 0)
        {
            Debug.Log("NEW ANIMATION " + "STAND " + animationName);
            Animator.Play("Player_Stand", 0, 0f);
            AnimationTime = 0.5f;
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
            if (AreImagesOverlapping(trainingObject._image, _characterCollision))
            {
                _trainingObjects.Remove(trainingObject);
                Destroy(trainingObject._image);
                Destroy(trainingObject);
                StartNewGame();
                Debug.Log("Collision with character");
            }
            else if (AreImagesOverlapping(trainingObject._image, _starDespawnCollision))
            {
                _trainingObjects.Remove(trainingObject);
                Destroy(trainingObject._image);
                Destroy(trainingObject);
                Debug.Log("Star despawning");
            }
            else if (AreImagesOverlapping(trainingObject._image, trainingObject._collision))
            {
                if (Input.GetKeyDown(_lastKey))
                {
                    if ((int)_lastKey == trainingObject._collisionKey)
                    {
                        _trainingObjects.Remove(trainingObject);
                        Destroy(trainingObject._image);
                        Destroy(trainingObject);
                        if (trainingObject._trainingObjectType.Equals(SwordTrainingObject.TrainingObjectType.Apple))
                            _score++;
                        else _score += 5;
                        UpdateScoreText();
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
                    IsNewKey = true;
                    _lastKey = key;
                    break;
                }
            }
        }
    }

    private void StartNewGame()
    {
        _score = 0;
        _speed = 2f;
        UpdateScoreText();
    }

    private void ChangeSpeed()
    {
        int mult = 1 + (_score / 5);
        int maxTrainingObjects = 1 + (_score / 15);
        _speed = 2.0f + (0.2f * mult);
        _maxTrainingObjects = maxTrainingObjects;
    }

    private void UpdateScoreText()
    {
        _scoreText.text = "Score: " + _score;
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
        AnimationTime -= Time.deltaTime;
        ChangeSpeed();
        CheckForKeys();
        UpdateObjectLocation();
        CheckForCollision();
    }
}
