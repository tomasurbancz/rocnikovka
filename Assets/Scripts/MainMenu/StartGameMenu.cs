using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartGameMenu : MonoBehaviour
{

    public GameObject _menu;
    public GameObject _startGameMenu;
    public GameObject _loginMenu;

    public Button _loginButton;
    public TMP_InputField _loginUsernameInputField;
    public TMP_InputField _loginPasswordInputField;

    private Vector2 _startPosition;
    private Vector2 _currentPosition;
    private Vector2 _nextPosition;
    private bool _hideWhenClickAway;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startPosition = new Vector2 (_menu.transform.position.x, _menu.transform.position.y);
        _currentPosition = _menu.transform.position;
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
        Vector2 direction = new Vector2(0, Mathf.Max(Mathf.Min(_nextPosition.y - _currentPosition.y, 0.075f), -0.075f));
        _currentPosition = new Vector2(0, _currentPosition.y + direction.y);
        _menu.transform.position = _currentPosition;
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

    public void CheckForButtonAvalability(int id)
    {
        TMP_InputField usernameField = null;
        TMP_InputField passwordField = null;
        Button button = null;

        Debug.Log(id);

        switch (id)
        {
            case 1:
                {
                    usernameField = _loginUsernameInputField;
                    passwordField = _loginPasswordInputField;
                    button = _loginButton;
                    break;
                }
        }

        string usernameFieldText = usernameField.text.Replace("\u200B", "").Trim();
        string passwordFieldText = passwordField.text.Replace("\u200B", "").Trim();
        if(string.IsNullOrEmpty(usernameFieldText) || string.IsNullOrEmpty(passwordFieldText)) 
        {
            HideButton(button);
        }
        else
        {
            ShowButton(button);
        }
    }

    private void HideButton(Button button)
    {
        Color color = button.GetComponentInChildren<TMP_Text>().color;
        button.interactable = false;
        color.a = 0.5f;
        button.GetComponentInChildren<TMP_Text>().color = color;
    }
    private void ShowButton(Button button)
    {
        Color color = button.GetComponentInChildren<TMP_Text>().color;
        button.interactable = true;
        color.a = 1f;
        button.GetComponentInChildren<TMP_Text>().color = color;
    }

    public void ChangePaperScene(int idMenu)
    {
        switch(idMenu)
        {
            case 0:
                {
                    _startGameMenu.SetActive(true);
                    _loginMenu.SetActive(false);
                    break;
                }
            case 1:
                {
                    _startGameMenu.SetActive(false);
                    _loginMenu.SetActive(true);
                    break;
                }
        }
    }

    public void CheckForLoginSuccessful(int id)
    {
        TMP_InputField usernameField = null;
        TMP_InputField passwordField = null;

        switch (id)
        {
            case 1:
                {
                    usernameField = _loginUsernameInputField;
                    passwordField = _loginPasswordInputField;
                    break;
                }
        }

        string usernameFieldText = usernameField.text.Replace("\u200B", "").Trim();
        string passwordFieldText = passwordField.text.Replace("\u200B", "").Trim();
    }
}
