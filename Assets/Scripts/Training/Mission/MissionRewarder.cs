using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionRewarder
{
    private Type RewardType;

    public enum Type
    {
        Sword, Armor
    }

    public MissionRewarder(Type rewardType)
    {
        RewardType = rewardType;
    }

    public void Reward(int value)
    {
        Account account = Account.GetCurrentAccount();
        Debug.Log(RewardType);
        Debug.Log(account.AccountStats.Damage + " " + account.AccountStats.Hp);
        switch (RewardType)
        {
            case Type.Sword:
            {
                account.AccountStats.Damage += value;
                break;
            }
            case Type.Armor:
            {
                account.AccountStats.Hp += value;
                break;
            }
        }
        Debug.Log(account.AccountStats.Damage + " " + account.AccountStats.Hp);
        account.SaveData();
    }
}
