using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public Animator Animator;
    public TMP_Text ChestText;
    public Button ContinueButton;
    public CoinSpawner CoinSpawner;
    public Image chest;
    private bool _opened = false;
    private CoinTracker _coinTracker;

    public void Open()
    {
        if(!_opened)
        {
            ChestText.color = new Color(0, 0, 0, 0);
            Animator.SetTrigger("OpenChest");
            _opened = true;
            _coinTracker = CoinSpawner.SpawnCoins(100 * Saver.GetInt("FightingLevel"), 10, chest.transform.position);
        }
    }

    public void Update()
    {
        if (_opened)
        {
            Debug.Log(_coinTracker.Remaining);
            if (_coinTracker.Remaining <= 0)
            {
                ContinueButton.gameObject.SetActive(true);
            }
        }
    }
}
