using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckIfHaveLocalAccount : MonoBehaviour
{
    private bool _haveLocalAccount;
    public Button _button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CheckIfLocalAccountExists();
        if(!_haveLocalAccount) ChangeButton();
    }

    private void CheckIfLocalAccountExists()
    {
        _haveLocalAccount = Saver.HasKey("LocalSavedName");
    }

    private void ChangeButton()
    {
        _button.interactable = false;
        Transform child = transform.GetChild(0);
        TMP_Text tmpText = child.GetComponent<TMP_Text>();
        tmpText.color = new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
