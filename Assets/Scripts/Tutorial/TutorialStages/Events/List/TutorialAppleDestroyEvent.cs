using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAppleDestroyEvent : TutorialEvent
{
    private bool _finished;
    private TutorialTextEvent _tutorialTextEvent;

    public TutorialAppleDestroyEvent()
    {
        _tutorialTextEvent = new TutorialTextEvent(TutorialSceneSetup.CurrentScene.Text, "Use the W, S, D keys to break apples. Use the A key to catch stars.");
    }

    public override void Update()
    {
        if (!_finished)
        {
            if (SwordTraining.RemainingTutorialApples <= 0) _finished = true;
        }
        _tutorialTextEvent.Update();
    }

    public override bool IsCompleted()
    {
        return _finished;
    }

    public override bool IsPaperNeeded()
    {
        return true;
    }

    public override void Click(string objectName)
    {

    }

    public override bool InstantlyMoveToNext()
    {
        return IsCompleted();
    }
}
