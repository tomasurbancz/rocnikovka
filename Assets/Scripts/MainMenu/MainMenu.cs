using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Image _mainMenuImage;
    private Vector2 _size;
    private Vector2 _currentPosition;
    private Vector2 _direction;
    private Vector2 _lastDirection;
    private float _cooldown = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _size = new Vector2(2.5f, 2.5f);
        _currentPosition = new Vector2(0, 0);
        _direction = new Vector2(0, 0);
        GetNewDirection(0);
    }

    private void GetNewDirection(int collision)
    {
        _lastDirection = _direction;
        int randomX = Random.Range(0, 6) + 5;
        int randomY = Random.Range(0, 6) + 5;
        if (collision == 0)
        {
            if (_lastDirection.x < 0)
            {
                randomX = Mathf.Abs(randomX);
            }
            else
            {
                randomX = -Mathf.Abs(randomX);
            }
        }
        else
        {
            if (_lastDirection.y < 0)
            {
                randomY = Mathf.Abs(randomY);
            }
            else
            {
                randomY = -Mathf.Abs(randomY);
            }
        }
        _direction = new Vector2(randomX, randomY);
    }

    private void Move()
    {
        _currentPosition = new Vector2(_currentPosition.x + (_direction.x/10 * Time.deltaTime), _currentPosition.y + (_direction.y/10 * Time.deltaTime));
        _mainMenuImage.transform.position = _currentPosition;
    }

    private void CheckForBorderCollision()
    {
        if((_currentPosition.x <= -_size.x || _currentPosition.x >= _size.x) || (_currentPosition.y <= -_size.y|| _currentPosition.y >= _size.y) && _cooldown <= 0)
        {
            if((_currentPosition.x <= -_size.x || _currentPosition.x >= _size.x)) GetNewDirection(0);
            if((_currentPosition.y <= -_size.y || _currentPosition.y >= _size.y)) GetNewDirection(1);
            _cooldown = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        CheckForBorderCollision();
        if(_cooldown >= 0)
        {
            _cooldown -= Time.deltaTime;
        }
    }
}
