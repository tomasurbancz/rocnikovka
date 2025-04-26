using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartGameMenu : MonoBehaviour
{

    public GameObject Menu;
    public GameObject StartGameMenuObjects;
    public GameObject NewGameMenu;

    private Vector2 _startPosition;
    private Vector2 _currentPosition;
    private Vector2 _nextPosition;
    private bool _hideWhenClickAway;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startPosition = new Vector2 (Menu.transform.position.x, Menu.transform.position.y);
        _currentPosition = Menu.transform.position;
        _nextPosition = _startPosition;
        _hideWhenClickAway = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void CheckForMouseClick()
    {
        if(_hideWhenClickAway)
        {
            MoveToStart();
        }
    }

    private void Move()
    {
        Vector2 direction = new Vector2(0, Mathf.Max(Mathf.Min(_nextPosition.y - _currentPosition.y, 20f * Time.deltaTime), -20f * Time.deltaTime));
        _currentPosition = new Vector2(0, _currentPosition.y + direction.y);
        Menu.transform.position = _currentPosition;
    }

    public void MoveToCenter()
    {
        _nextPosition = new Vector2(0, 0);
        _hideWhenClickAway = true;
    }

    public void MoveToStart()
    {
        _nextPosition = _startPosition;
        _hideWhenClickAway = false;
    }

    public void ChangePaperScene(int idMenu)
    {
        switch(idMenu)
        {
            case 0:
                {
                    StartGameMenuObjects.SetActive(true);
                    NewGameMenu.SetActive(false);
                    break;
                }
            case 1:
                {
                    StartGameMenuObjects.SetActive(false);
                    NewGameMenu.SetActive(true);
                    break;
                }
        }
    }
}
