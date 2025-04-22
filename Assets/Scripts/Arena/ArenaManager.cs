using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaManager : MonoBehaviour
{
    public List<Button> Buttons;

    // Start is called before the first frame update
    void Start()
    {
        Account account = Account.GetCurrentAccount();
        int current = account.ArenaLevel;
        for(int i = 0; i < Mathf.Min(current, Buttons.Count); i++)
        {
            Buttons[i].interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
