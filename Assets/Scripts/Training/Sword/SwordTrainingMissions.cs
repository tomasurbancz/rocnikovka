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
        missions.Add(new Mission(MissionType.SCORE, 20, 2));
        missions.Add(new Mission(MissionType.TIME, 10, 3));
        missions.Add(new Mission(MissionType.APPLES, 30, 4));
        missions.Add(new Mission(MissionType.STARS_IN_ROW, 5, 5));
        missions.Add(new Mission(MissionType.SCORE, 50, 6));
        missions.Add(new Mission(MissionType.TIME, 15, 7));
        missions.Add(new Mission(MissionType.APPLES, 50, 8));
        missions.Add(new Mission(MissionType.STARS, 10, 9));
        missions.Add(new Mission(MissionType.SCORE, 65, 10));
        missions.Add(new Mission(MissionType.TIME, 20, 11));
        missions.Add(new Mission(MissionType.APPLES, 70, 12));
        missions.Add(new Mission(MissionType.STARS_IN_ROW, 8, 13));
        missions.Add(new Mission(MissionType.SCORE, 80, 14));
        missions.Add(new Mission(MissionType.TIME, 25, 15));
        missions.Add(new Mission(MissionType.APPLES, 80, 16));
        missions.Add(new Mission(MissionType.STARS, 20, 17));
        missions.Add(new Mission(MissionType.SCORE, 110, 18));
        missions.Add(new Mission(MissionType.TIME, 35, 19));
        return missions;
    }
}
