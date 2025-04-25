using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialChangeSceneEvent : TutorialEvent
{
    private string _scene;
    private bool _teleported;

    public TutorialChangeSceneEvent(string scene)
    {
        _scene = scene;
    }

    public override void Update()
    {
        if(!_teleported)
        {
            _teleported = true;
            Menu.ChangeTutorialScene(_scene);
        }
    }

    public override bool IsCompleted()
    {
        return _teleported;
    }

    public override bool IsPaperNeeded()
    {
        return false;
    }

    public override void Click(string objectName)
    {
        
    }

    public override bool InstantlyMoveToNext()
    {
        return IsCompleted();
    }
}
