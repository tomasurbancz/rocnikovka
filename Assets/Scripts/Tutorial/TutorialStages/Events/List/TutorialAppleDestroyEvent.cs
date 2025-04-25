using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAppleDestroyEvent : TutorialEvent
{
    private bool _finished;

    public TutorialAppleDestroyEvent()
    {

    }

    public override void Update()
    {
        if (!_finished)
        {
            if (SwordTraining.RemainingTutorialApples <= 0) _finished = true;
        }
    }

    public override bool IsCompleted()
    {
        return _finished;
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
