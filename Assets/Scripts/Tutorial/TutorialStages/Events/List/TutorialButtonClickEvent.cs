using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TutorialButtonClickEvent : TutorialEvent
{
    private bool _completed;
    private string _objectName;
    private TutorialTextEvent _tutorialTextEvent;
    private Image _pointer;
    private bool _showedPointer = false;

    public TutorialButtonClickEvent(TMP_Text text, string objectName, string overwrite = "", int offset = 0)
    {
        string textToWrite = overwrite;
        if (textToWrite.Equals("")) textToWrite = objectName;
        _tutorialTextEvent = new TutorialTextEvent(text, $"Continue by pressing the {textToWrite} button");
        _objectName = objectName;
        try
        {
            _pointer = TutorialSceneSetup.CurrentScene.Arrow[offset];
        } catch(Exception e)
        {

        }
    }

    public override void Update()
    {
        if(!_tutorialTextEvent.IsCompleted())
        {
            _tutorialTextEvent.Update();
        }
        else
        {
            if(!_showedPointer)
            {
                _pointer.gameObject.SetActive(true);
                _showedPointer = true;
            }
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

    public override void DeleteChanges()
    {
    }
}
