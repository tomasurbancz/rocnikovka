using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Entity
{
    public HealthBar HealthBar;
    public TMP_Text CharacterNameLocation;
    public int Damage;
    public float BlockChance;
    public float CritChance;
    public string Name;
    public int MaxHP;
    public Fighting Fighting;
    public Vector2 StartPosition;

    public Image Collision1;
    public Image Collision2;
    public Image Collision3;
    public Image Collision4;

    private Entity _enemy;

    private TMP_Text _critical;
    private TMP_Text _blocked;

    private Vector2 _currentPosition;
    public Type EntityType;
    private Vector2 _direction;
    private Image _image;

    public enum Type
    {
        Player, Bird, Spider, Frog, Mouse
    }


    public Entity(int damage, float blockChance, float critChance, string name, int maxHP, Type type)
    {
        Damage = damage;
        BlockChance = blockChance;
        CritChance = critChance;
        Name = name;
        MaxHP = maxHP;
        EntityType = type;
        _direction = new Vector2(0, 0);
    }

    public void StartMoving(Entity entity)
    {
        _critical.gameObject.SetActive(false);
        _blocked.gameObject.SetActive(false);
        _enemy = entity;
        _direction = new Vector2(1, 0);
    }

    private void PrintCritBlock(TMP_Text text)
    {
        text.gameObject.SetActive(true);
    }


    public void Attack()
    {
        int random = Random.Range(0, 10000);
        if((_enemy.BlockChance * 100) > random)
        {
            PrintCritBlock(_blocked);
            Debug.Log("BLOCKED");
        }
        else
        {
            random = Random.Range(0, 10000);
            int damage = Damage;
            if ((CritChance * 100) > random)
            {
                damage *= 2;
                PrintCritBlock(_critical);
                Debug.Log("CRITICAL");
            }
            _enemy.TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        HealthBar.UpdateHP(damage);
        if(HealthBar.HP <= 0)
        {
            Fighting.Defeated(this);
        }
    }

    public void Update()
    {
        Move();
    }

    private void Move()
    {
        if (EntityType.Equals(Type.Player))
        {
            if(_direction.x == 1)
            {
                _currentPosition.x += 15f * Time.deltaTime;
                if(AreImagesOverlapping(_image, Collision4))
                {
                    Attack();
                    _direction.x = -1;
                }
            }
            else if (_direction.x == -1)
            {
                _currentPosition.x -= 15f * Time.deltaTime;
                if (AreImagesOverlapping(_image, Collision1))
                {
                    _direction.x = 0;
                }
            }
        }
        else
        {
            if (_direction.x == 1)
            {
                _currentPosition.x -= 15f * Time.deltaTime;
                if (AreImagesOverlapping(_image, Collision3))
                {
                    Attack();
                    _direction.x = -1;
                }
            }
            else if (_direction.x == -1)
            {
                _currentPosition.x += 15f * Time.deltaTime;
                if (AreImagesOverlapping(_image, Collision2))
                {
                    _direction.x = 0;
                }
            }
        }
        _image.transform.position = _currentPosition;
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

    public void SetUp(Slider slider, TMP_Text healthText, TMP_Text characterNameLocation, Fighting fighting, Image spawn, Sprite sprite, Image collision1, Image collision2, Image collision3, Image collision4, TMP_Text critical, TMP_Text blocked)
    {
        _critical = critical;
        _blocked = blocked;
        Collision1 = collision1;
        Collision2 = collision2;
        Collision3 = collision3;
        Collision4 = collision4;
        Fighting = fighting;
        HealthBar = new HealthBar(slider, healthText, MaxHP, MaxHP);
        CharacterNameLocation = characterNameLocation;
        CharacterNameLocation.text = Name;
        HealthBar.UpdateHP(0);
        _currentPosition = spawn.transform.position;
        StartPosition = _currentPosition.ToNewVector2();
        if(!EntityType.Equals(Type.Player)) spawn.sprite = sprite;
        _image = spawn;
        Show();
    }

    public void Hide()
    {
        Color color = _image.color;
        color = new Color(color.r, color.g, color.b, 0);
        _image.color = color;
        _image.transform.position = StartPosition;
    }

    public void Show()
    {
        Color color = _image.color;
        color = new Color(color.r, color.g, color.b, 1);
        _image.color = color;
        _image.transform.position = StartPosition;
    }
}
