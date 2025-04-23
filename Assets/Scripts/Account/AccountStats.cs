using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AccountStats
{
    public int Damage;
    public int Hp;
    public float BlockChance;
    public float CritChance;
    public int Coins;

    public AccountStats(int damage, int hp, float blockChance, float critChance, int coins)
    {
        Damage = damage;
        Hp = hp;
        BlockChance = blockChance;
        CritChance = critChance;
        Coins = coins;
    }
}

