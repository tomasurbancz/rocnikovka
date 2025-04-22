using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission
{

    private MissionType _missionType;
    private int _request;
    private int _current;
    private int _index;

    public Mission(MissionType missionType, int request, int index)
    {
        _missionType = missionType;
        _request = request;
        _current = 0;
        _index = index;
    }

    public void SetProgress(int current)
    {
        _current = current;
    }

    public void AddProgress(int progressToAdd)
    {
        _current += progressToAdd;
    }

    public bool IsCompleted()
    {
        return _current >= _request;
    }

    public MissionType GetMissionType()
    {
        return _missionType;
    }
    public MissionInfo GetMissionInfo()
    {
        return new MissionInfo(GetHeader(), GetInfo());
    }

    private string GetHeader()
    {
        return "Mission # " + (_index + 1);
    }

    private string GetInfo()
    {
        string startText = "";
        switch (_missionType)
        {
            case MissionType.APPLES:
                startText = "Break apples";
                break;
            case MissionType.SCORE:
                startText = "Reach score";
                break;
            case MissionType.STARS:
                startText = "Catch stars";
                break;
            case MissionType.STARS_IN_ROW:
                startText = "Catch stars in row";
                break;
            case MissionType.TIME:
                startText = "No mistake (sec)";
                break;
        }
        return startText + " " + _current + "/" + _request;
    }

    public void ResetIfType(MissionType missionType)
    {
        if (_missionType.Equals(missionType)) SetProgress(0);
    }

    public void ResetIfNotType(MissionType missionType)
    {
        if (!_missionType.Equals(missionType)) SetProgress(0);
    }
}
