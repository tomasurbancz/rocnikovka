using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Account
{
    public string Name;
    public int ArenaLevel;
    public TrainingStats ArmorStats;
    public TrainingStats SwordStats;
    public AccountStats AccountStats;
    public AccountMissions AccountMissions;
    public AccountUpgrades AccountUpgrades;

    public Account(string name, int arenaLevel, TrainingStats armorStats, TrainingStats swordStats, AccountStats accountStats, AccountMissions accountMissions, AccountUpgrades accountUpgrades)
    {
        Name = name;
        ArenaLevel = arenaLevel;
        ArmorStats = armorStats;
        SwordStats = swordStats;
        AccountStats = accountStats;
        AccountMissions = accountMissions;
        AccountUpgrades = accountUpgrades;
        SaveData();
    }

    public abstract void SaveData();

    public static Account GetCurrentAccount()
    {
        if (Saver.GetString("LoginType").Equals("Local")) return new LocalAccount();
        return null;
    }
}
