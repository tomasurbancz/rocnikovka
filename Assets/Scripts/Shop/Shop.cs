using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public TMP_Text Text;
    public TMP_Text Coins;
    public TMP_Text ArmorPrice;
    public TMP_Text SwordPrice;
    private Vector2 _startPos;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = Text.transform.position;
        UpdateTexts();
        Account account = Account.GetCurrentAccount();
        Debug.Log("CURRENT COINS: " + account.AccountStats.Coins);
    }

    // Update is called once per frame
    void Update()
    {
        Text.transform.position = new Vector2(_startPos.x, Text.transform.position.y + 5f * Time.deltaTime);
    }

    private void PrintText(string text, Color color)
    {
        Text.text = text;
        Text.transform.position = _startPos;
        Text.color = color;
    }

    private void UpdateTexts()
    {
        Account account = Account.GetCurrentAccount();
        Coins.text = account.AccountStats.Coins + "";
        ArmorPrice.text = "Price: " + ((account.AccountUpgrades.Armor + 1) * 150);
        SwordPrice.text = "Price: " + ((account.AccountUpgrades.Sword + 1) * 150);
    }

    public void Purchase(int id)
    {
        Account account = Account.GetCurrentAccount();

        switch (id)
        {
            case 0: { 
                if((account.AccountUpgrades.Armor + 1) * 150 <= account.AccountStats.Coins) {
                    account.AccountUpgrades.Armor++;
                    account.AccountStats.Coins -= account.AccountUpgrades.Armor * 150;
                    account.AccountStats.Hp += 15;
                    account.SaveData();
                    PrintText("Armor upgrade purchased for " + (account.AccountUpgrades.Armor * 150) + "\n+15 HP", Color.green);
                    UpdateTexts();
                    return;
                }
                break;
            }
            case 1: {
                if ((account.AccountUpgrades.Sword + 1) * 150 <= account.AccountStats.Coins)
                {
                    account.AccountUpgrades.Sword++;
                    account.AccountStats.Coins -= account.AccountUpgrades.Sword * 150;
                    account.AccountStats.Damage += 15;
                    account.SaveData();
                    PrintText("Sword upgrade purchased for " + (account.AccountUpgrades.Sword * 150) + "\n+15 Damage", Color.green);
                    UpdateTexts();
                    return;
                }
                break;
            }
        }
 
        PrintText("Not enought money", Color.red);
    }
}