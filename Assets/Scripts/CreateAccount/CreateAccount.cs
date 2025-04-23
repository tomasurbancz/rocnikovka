using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateAccount : MonoBehaviour
{
    private string _name;
    public TMP_InputField NameField;
    public Button CreateButton;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckForButtonClickable();
    }

    public void InputChange()
    {
        _name = NameField.text.Replace("\u200B", "").Trim();
    }
    
    public void CheckForButtonClickable()
    {
        Color color = CreateButton.GetComponentInChildren<TMP_Text>().color;
        string userInput = NameField.text.Replace("\u200B", "").Trim();
        if (string.IsNullOrEmpty(userInput))
        {
            CreateButton.interactable = false;
            color.a = 0.5f;
        }
        else
        {
            CreateButton.interactable = true;
            color.a = 1f;
        }
        CreateButton.GetComponentInChildren<TMP_Text>().color = color;
    }

    public void CreateRandomCharacter()
    {
        UpdateName();
    }

    public void Create()
    {
        new LocalAccount(_name);
    }

    private void UpdateName()
    {
        
        _name = RandomName.GetNameFromList();
        NameField.text = _name;
    }
}