using System.Collections.Generic;
using UnityEngine;

public abstract class TutorialStage
{
    public TutorialEvent _tutorialEvent;
    private bool _started;

    public void Activate()
    {
        _started = true;
        if (_tutorialEvent.IsPaperNeeded())
        {
            TutorialSceneSetup.CurrentScene.Paper.gameObject.SetActive(true);
        }
        else
        {
            TutorialSceneSetup.CurrentScene.Paper.gameObject.SetActive(false);
        }
    }

    public bool IsCompleted()
    {
        return _tutorialEvent.IsCompleted();
    }

    public void Update()
    {
        if (_started) _tutorialEvent.Update();
    }

    public bool InstantlyMoveToNext()
    {
        return _tutorialEvent.InstantlyMoveToNext();
    }

    public void DeleteChanges()
    {
        _tutorialEvent.DeleteChanges();
    }
}
