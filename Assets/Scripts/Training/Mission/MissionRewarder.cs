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
        account.SaveData();
    }
}
