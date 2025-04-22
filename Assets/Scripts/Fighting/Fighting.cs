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

    private Entity PlayerEntity;
    private Entity CurrentEntity;
    private List<Entity> Entities;
    private int progress = 0;
    private float Cooldown = 0.3f;
    private Entity CurrentAttacking;
    private Entity CurrentDefending;

    private bool playing = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartNewGame();
    }

    private void SetUpEnemies()
    {
        int level = Saver.GetInt("FightingLevel");
        switch(level)
        {
            case 1:
                {
                    Entities = new Level1().GetEntities();
                    break;
                }
            case 2:
                {
                    Entities = new Level1().GetEntities();
                    break;
                }
            case 3:
                {
                    Entities = new Level1().GetEntities();
                    break;
                }
            case 4:
                {
                    Entities = new Level1().GetEntities();
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Cooldown > 0)
        {
            CurrentAttacking.Update();
        }
        if (Cooldown <= 0 && playing)
        {
            Attack();
            Entity copyOfAttacking = CurrentAttacking;
            CurrentAttacking = CurrentDefending;
            CurrentDefending = copyOfAttacking;
        }
        Cooldown -= Time.deltaTime;
    }

    public void Defeated(Entity entity)
    {
        if (entity.EntityType.Equals(Entity.Type.Player))
        {
            EndGame();
        }
        else
        {
            progress++;
            if(Entities.Count > progress) {
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
        CurrentEntity.Hide();

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
        CurrentAttacking.StartMoving(CurrentDefending);
        Cooldown = 1.5f;
    }

    private void SpawnNewEntity()
    {
        if(CurrentEntity != null)
        {
            CurrentEntity.Hide();
        }
        CurrentEntity = Entities[progress];
        switch(CurrentEntity.EntityType)
        {
            case Entity.Type.Spider:
                {
                    CurrentEntity.SetUp(Slider2, HealthText2, Text2, this, EnemySpawn1, SpiderTexture, Collision1, Collision2, Collision3, Collision4);
                    break;
                }
            case Entity.Type.Frog:
                {
                    CurrentEntity.SetUp(Slider2, HealthText2, Text2, this, EnemySpawn1, FrogTexture, Collision1, Collision2, Collision3, Collision4);
                    break;
                }
            case Entity.Type.Bird:
                {
                    CurrentEntity.SetUp(Slider2, HealthText2, Text2, this, EnemySpawn2, BirdTexture, Collision1, Collision2, Collision3, Collision4);
                    break;
                }
            case Entity.Type.Mouse:
                {
                    CurrentEntity.SetUp(Slider2, HealthText2, Text2, this, EnemySpawn1, MouseTexture, Collision1, Collision2, Collision3, Collision4);
                    break;
                }
        }
        CurrentAttacking = PlayerEntity;
        CurrentDefending = CurrentEntity;
    }

    public void StartNewGame()
    {
        Account account = Account.GetCurrentAccount();
        AccountStats accountStats = account.AccountStats;
        PlayerEntity = new Entity(accountStats.Damage, accountStats.BlockChance, accountStats.CritChance, account.Name, accountStats.Hp, Entity.Type.Player);
        PlayerEntity.SetUp(Slider1, HealthText1, Text1, this, Player, null, Collision1, Collision2, Collision3, Collision4);
        SetUpEnemies();
        SpawnNewEntity();
        //CurrentAttacking.StartMoving(CurrentDefending);
        Cooldown = 0.5f;
        progress = 0;
        playing = true;
        HideButtons();
    }

    private void ShowButtons()
    {
        BackButton.image.color = BackButton.image.color.GetVisibleColor();
        BackText.color = BackText.color.GetVisibleColor();
        RetryButton.image.color = RetryButton.image.color.GetVisibleColor();
        RetryText.color = RetryText.color.GetVisibleColor();
    }
    private void HideButtons()
    {
        BackButton.image.color = BackButton.image.color.GetTransparentColor();
        BackText.color = BackText.color.GetTransparentColor();
        RetryButton.image.color = RetryButton.image.color.GetTransparentColor();
        RetryText.color = RetryText.color.GetTransparentColor();
    }

    private void EndGame()
    {
        playing = false;
        PlayerEntity.Hide();
        ShowButtons();
    }
    
}
