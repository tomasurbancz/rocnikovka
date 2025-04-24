using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrainingMissions : MissionList
{
    public override List<Mission> GetMissions()
    {
        List<Mission> missions = new List<Mission>();
        MissionRewarder missionRewarder = new MissionRewarder(MissionRewarder.Type.Sword);
        missions.Add(new Mission(MissionType.APPLES, 10, 0));
        missions.Add(new Mission(MissionType.STARS, 5, 1));
        return missions;
    }
}
