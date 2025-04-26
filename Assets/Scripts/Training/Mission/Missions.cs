using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Missions 
{
    private MissionList _missionList;
    private Mission _currentMission;
    private int _currentMissionIndex;
    private TMP_Text _headerText;
    private TMP_Text _infoText;
    private MissionRewarder _missionRewarder;
    private string _textInSaver;

    public Missions(MissionList missionList, string textInSaver, TMP_Text headerText, TMP_Text infoText, MissionRewarder missionRewarder)
    {
        _missionList = missionList;
        _textInSaver = textInSaver;
        int currentMissionIndex = 0;
        Account account = Account.GetCurrentAccount();
        if (_textInSaver.Contains("Armor")) currentMissionIndex = account.AccountMissions.Armor;
        else currentMissionIndex = account.AccountMissions.Sword;
        _currentMissionIndex = currentMissionIndex;
        _currentMission = _missionList.GetMissions()[_currentMissionIndex - 1];
        _headerText = headerText;
        _infoText = infoText;
        _missionRewarder = missionRewarder;
        UpdateText();
    }

    public void UpdateMission(MissionType missionType, int val, bool overwrite = false)
    {
        if(missionType.Equals(_currentMission.GetMissionType()))
        {
            if (overwrite) _currentMission.SetProgress(val);
            else _currentMission.AddProgress(val);

            if (_currentMission.IsCompleted())
            {
                _missionRewarder.Reward(12);
                ChangeMission();
            }
        }
        UpdateText();
    }

    public void ResetIfType(MissionType missionType)
    {
        _currentMission.ResetIfType(missionType);
        UpdateText();
    }

    public void ResetIfNotType(MissionType missionType)
    {
        _currentMission.ResetIfNotType(missionType);
        UpdateText();
    }

    private void ChangeMission()
    {
        _currentMissionIndex++;
        Account account = Account.GetCurrentAccount();
        if (_textInSaver.Contains("Armor")) account.AccountMissions.Armor = _currentMissionIndex;
        else account.AccountMissions.Sword = _currentMissionIndex;
        account.SaveData();
        _currentMission = _missionList.GetMissions()[_currentMissionIndex - 1];
    }

    private void UpdateText()
    {
        MissionInfo info = _currentMission.GetMissionInfo();
        _headerText.text = info.GetHeader();
        _infoText.text = info.GetInfo();
    }
}
