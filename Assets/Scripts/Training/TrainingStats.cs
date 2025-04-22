using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingStats
{
    public Type TrainingType;
    public int Max;
    public int MissionId;

    public enum Type
    {
        Armor,
        Sword
    }

    public TrainingStats(Type type, int max, int missionId)
    {
        TrainingType = type;
        Max = max;
        MissionId = missionId;
    }
}
