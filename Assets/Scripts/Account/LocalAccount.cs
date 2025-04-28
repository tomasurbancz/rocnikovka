using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalAccount : Account
{
    public LocalAccount(string name) : base(name,
        1,
        new TrainingStats(TrainingStats.Type.Armor, 0, 1),
        new TrainingStats(TrainingStats.Type.Sword, 0, 1),
        new AccountStats(2, 40, 1.5f, 3.5f, 0),
        new AccountMissions(1, 1),
        new AccountUpgrades(0, 0)
        )
    {

    }

    public LocalAccount() : base(Saver.GetString("LocalSavedName"),
        Saver.GetInt("LocalArenaLevel"),
        new TrainingStats(TrainingStats.Type.Armor, Saver.GetInt("LocalTrainingArmorMax"), Saver.GetInt("LocalTrainingArmorMissionId")),
        new TrainingStats(TrainingStats.Type.Sword, Saver.GetInt("LocalTrainingSwordMax"), Saver.GetInt("LocalTrainingSwordMissionId")),
        new AccountStats(Saver.GetInt("LocalDamage"), Saver.GetInt("LocalHp"), Saver.GetFloat("LocalBlockChance"), Saver.GetFloat("LocalCritChance"), Saver.GetInt("LocalCoins")),
        new AccountMissions(Saver.GetInt("LocalSwordMission"), Saver.GetInt("LocalArmorMission")),
        new AccountUpgrades(Saver.GetInt("LocalSwordUpgrade"), Saver.GetInt("LocalArmorUpgrade"))
        )
    {

    }

    public override void SaveData()
    {
        Saver.SaveString("LocalSavedName", Name);
        Saver.SaveInt("LocalArenaLevel", ArenaLevel);
        Saver.SaveInt("LocalTrainingArmorMax", ArmorStats.Max);
        Saver.SaveInt("LocalTrainingArmorMissionId", ArmorStats.MissionId);
        Saver.SaveInt("LocalTrainingSwordMax", SwordStats.Max);
        Saver.SaveInt("LocalTrainingSwordMissionId", SwordStats.MissionId);
        Saver.SaveInt("LocalDamage", AccountStats.Damage);
        Saver.SaveInt("LocalHp", AccountStats.Hp);
        Saver.SaveFloat("LocalBlockChance", AccountStats.BlockChance);
        Saver.SaveFloat("LocalCritChance", AccountStats.CritChance);
        Saver.SaveInt("LocalCoins", AccountStats.Coins);
        Saver.SaveInt("LocalSwordMission", AccountMissions.Sword);
        Saver.SaveInt("LocalArmorMission", AccountMissions.Armor);
        Saver.SaveInt("LocalSwordUpgrade", AccountUpgrades.Sword);
        Saver.SaveInt("LocalArmorUpgrade", AccountUpgrades.Armor);
        Saver.SaveString("LoginType", "Local");
        Saver.Save();
    }
}
