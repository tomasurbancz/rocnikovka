using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Fighting : MonoBehaviour
{
    public Image Player;
    public Image EnemySpawn1;
    public Image EnemySpawn2;
    public Sprite MouseTexture;
    public Sprite SpiderTexture;
    public Sprite BirdTexture;
    public Sprite FrogTexture;

    public Slider Slider1;
    public Slider Slider2;
    public TMP_Text HealthText1;
    public TMP_Text HealthText2;
    public TMP_Text Text1;
    public TMP_Text Text2;

    public Image Collision1;
    public Image Collision2;
    public Image Collision3;
    public Image Collision4;

    public Button RetryButton;
    public TMP_Text RetryText;
    public Button BackButton;
    public TMP_Text BackText;

    public TMP_Text ChestText;
    public Button Chest;

    public TMP_Text PlayerCritical;
    public TMP_Text PlayerBlocked;
    public TMP_Text EnemyCritical;
    public TMP_Text EnemyBlocked;

    public Animator Animator;

    private Entity _playerEntity;
    private Entity _currentEntity;
    private List<Entity> _entities;
    private int _progress = 0;
    private float _cooldown = 0.3f;
    private Entity _currentAttacking;
    private Entity _currentDefending;


    private bool playing = true;

    private bool _firstGame = true;
    public static bool PlayerDied;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartNewGame();
        PlayerDied = false;
    }

    private void SetUpEnemies()
    {
        int level = Saver.GetInt("FightingLevel");
        Debug.Log("FIGHTING LEVEL: " + level);
        switch (level)
        {
            case 1:
                {
                    _entities = new Level1().GetEntities();
                    break;
                }
            case 2:
                {
                    _entities = new Level2().GetEntities();
                    break;
                }
            case 3:
                {
                    _entities = new Level3().GetEntities();
                    break;
                }
            case 4:
                {
                    _entities = new Level4().GetEntities();
                    break;
                }
            case 5:
                {
                    _entities = new Level5().GetEntities();
                    break;
                }
            case 6:
                {
                    _entities = new Level6().GetEntities();
                    break;
                }
            case 7:
                {
                    _entities = new Level7().GetEntities();
                    break;
                }
            case 8:
                {
                    _entities = new Level8().GetEntities();
                    break;
                }
            case 9:
                {
                    _entities = new Level9().GetEntities();
                    break;
                }
            case 10:
                {
                    _entities = new Level10().GetEntities();
                    break;
                }
            case 11:
                {
                    _entities = new Level11().GetEntities();
                    break;
                }
            case 12:
                {
                    _entities = new Level12().GetEntities();
                    break;
                }
            case 13:
                {
                    _entities = new Level13().GetEntities();
                    break;
                }
            case 14:
                {
                    _entities = new Level14().GetEntities();
                    break;
                }
            case 15:
                {
                    _entities = new Level15().GetEntities();
                    break;
                }
            case 16:
                {
                    _entities = new Level16().GetEntities();
                    break;
                }
            case 17:
                {
                    _entities = new Level17().GetEntities();
                    break;
                }
            case 18:
                {
                    _entities = new Level18().GetEntities();
                    break;
                }
            case 19:
                {
                    _entities = new Level19().GetEntities();
                    break;
                }
            case 20:
                {
                    _entities = new Level20().GetEntities();
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_cooldown > 0)
        {
            _currentAttacking.Update();
        }
        if (_cooldown <= 0 && playing)
        {
            Attack();
            Entity copyOfAttacking = _currentAttacking;
            _currentAttacking = _currentDefending;
            _currentDefending = copyOfAttacking;
        }
        _cooldown -= Time.deltaTime;
    }

    public void Defeated(Entity entity)
    {
        if (entity.EntityType.Equals(Entity.Type.Player))
        {
            EndGame();
        }
        else
        {
            _progress++;
            if(_entities.Count > _progress) {
                SpawnNewEntity();
            }
            else
            {
                Victory();
            }
        }
    }

    private void Victory()
    {
        playing = false;
        Chest.gameObject.SetActive(true);
        _currentEntity.Hide();

        Slider1.gameObject.SetActive(false);
        Text1.color = Text1.color.GetTransparentColor();
        Slider2.gameObject.SetActive(false);
        Text2.color = Text2.color.GetTransparentColor();

        Account account = Account.GetCurrentAccount();
        account.ArenaLevel = Mathf.Max(account.ArenaLevel, Saver.GetInt("FightingLevel") + 1);
        account.SaveData();
    }

    public void Attack()
    {
        _currentAttacking.StartMoving(_currentDefending);
        _cooldown = 1.5f;
    }

    private void SpawnNewEntity()
    {
        if(_currentEntity != null)
        {
            _currentEntity.Hide();
        }
        _currentEntity = _entities[_progress];
        switch(_currentEntity.EntityType)
        {
            case Entity.Type.Spider:
                {
                    _currentEntity.SetUp(Slider2, HealthText2, Text2, this, EnemySpawn1, SpiderTexture, Collision1, Collision2, Collision3, Collision4, EnemyCritical, EnemyBlocked, null);
                    break;
                }
            case Entity.Type.Frog:
                {
                    _currentEntity.SetUp(Slider2, HealthText2, Text2, this, EnemySpawn1, FrogTexture, Collision1, Collision2, Collision3, Collision4, EnemyCritical, EnemyBlocked, null);
                    break;
                }
            case Entity.Type.Bird:
                {
                    _currentEntity.SetUp(Slider2, HealthText2, Text2, this, EnemySpawn2, BirdTexture, Collision1, Collision2, Collision3, Collision4, EnemyCritical, EnemyBlocked, null);
                    break;
                }
            case Entity.Type.Mouse:
                {
                    _currentEntity.SetUp(Slider2, HealthText2, Text2, this, EnemySpawn1, MouseTexture, Collision1, Collision2, Collision3, Collision4, EnemyCritical, EnemyBlocked, null);
                    break;
                }
        }
        _currentAttacking = _playerEntity;
        _currentDefending = _currentEntity;
    }

    public void StartNewGame()
    {
        if (_firstGame || Tutorial.CompletedTutorial)
        {
            Account account = Account.GetCurrentAccount();
            AccountStats accountStats = account.AccountStats;
            _playerEntity = new Entity(accountStats.Damage, accountStats.BlockChance, accountStats.CritChance, account.Name, accountStats.Hp, Entity.Type.Player);
            _playerEntity.SetUp(Slider1, HealthText1, Text1, this, Player, null, Collision1, Collision2, Collision3, Collision4, PlayerCritical, PlayerBlocked, Animator);
            _progress = 0;
            SetUpEnemies();
            SpawnNewEntity();
            //CurrentAttacking.StartMoving(CurrentDefending);
            _cooldown = 0.5f;
            playing = true;
            _firstGame = false;
            HideButtons();
        }
    }

    private void ShowButtons()
    {
        BackButton.image.color = BackButton.image.color.GetVisibleColor();
        BackText.color = BackText.color.GetVisibleColor();
        BackButton.interactable = true;
        RetryButton.image.color = RetryButton.image.color.GetVisibleColor();
        RetryText.color = RetryText.color.GetVisibleColor();
        RetryButton.interactable = true;
    }
    private void HideButtons()
    {
        BackButton.image.color = BackButton.image.color.GetTransparentColor();
        BackText.color = BackText.color.GetTransparentColor();
        BackButton.interactable = false;
        RetryButton.image.color = RetryButton.image.color.GetTransparentColor();
        RetryText.color = RetryText.color.GetTransparentColor();
        RetryButton.interactable = false;
    }

    private void EndGame()
    {
        playing = false;
        _playerEntity.Hide();
        ShowButtons();
        PlayerDied = true;
    }
    
}
