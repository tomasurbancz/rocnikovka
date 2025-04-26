using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialButtonClickEvent : TutorialEvent
{
    private bool _completed;
    private string _objectName;
    private TutorialTextEvent _tutorialTextEvent;

    public TutorialButtonClickEvent(TMP_Text text, string objectName, string overwrite = "")
    {
        string textToWrite = overwrite;
        if (textToWrite.Equals("")) textToWrite = objectName;
        _tutorialTextEvent = new TutorialTextEvent(text, $"Continue by pressing the {textToWrite} button");
        _objectName = objectName;
    }

    public override void Update()
    {
        if(!_tutorialTextEvent.IsCompleted())
        {
            _tutorialTextEvent.Update();
        }
    }

    public override bool IsCompleted()
    {
        return _completed;
    }

    public override bool IsPaperNeeded()
    {
        return true;
    }

    public override void Click(string objectName)
    {
        Debug.Log("TEST: " + _objectName + " " + objectName);
        if(objectName.Equals(_objectName))
        {
            _completed = true;
        }
    }

    public override bool InstantlyMoveToNext()
    {
        return IsCompleted();
    }
}
