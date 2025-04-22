using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateAccount : MonoBehaviour
{
    string _name;
    public TMP_InputField _nameField;
    public Button _createButton;


    // Start is called before the first frame update
    void Start()
    {

    }

    Texture2D CreateTextureCopy(Texture2D original)
    {
        Texture2D copy = new Texture2D(original.width, original.height, TextureFormat.RGBA32, false);
        copy.SetPixels(original.GetPixels());
        copy.Apply();
        return copy;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForButtonClickable();
    }

    public void InputChange()
    {
        _name = _nameField.text.Replace("\u200B", "").Trim();
    }
    
    public void CheckForButtonClickable()
    {
        Color color = _createButton.GetComponentInChildren<TMP_Text>().color;
        string userInput = _nameField.text.Replace("\u200B", "").Trim();
        if (string.IsNullOrEmpty(userInput))
        {
            _createButton.interactable = false;
            color.a = 0.5f;
        }
        else
        {
            _createButton.interactable = true;
            color.a = 1f;
        }
        _createButton.GetComponentInChildren<TMP_Text>().color = color;
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
        _nameField.text = _name;
    }
}