using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTextEvent : TutorialEvent
{
    private float _cooldown = 0.1f;
    private string _currentText = "";
    private string _wantedText;
    private int _currentIndex = 0;
    private bool _running;
    private TMP_Text _text;

    public TutorialTextEvent(TMP_Text text, string wantedText)
    {
        _text = text;
        _wantedText = wantedText;
        _running = true;
    }

    private void PrintNewLetter()
    {
        _currentText += _wantedText.ToCharArray()[_currentIndex];
        _currentIndex++;
        if (_currentIndex >= _wantedText.Length) _running = false;
        UpdateText();
    }
    
    private void UpdateText()
    {
        if(_running) _text.text = _currentText + "_";
        else _text.text = _currentText;
    }

    public override void Update()
    {
        if (_running)
        {
            _cooldown -= Time.deltaTime;
            if (_cooldown <= 0)
            {
                _cooldown = 0.05f;
                PrintNewLetter();
            }
        }
    }

    public override bool IsCompleted()
    {
        return !_running;
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
        return false;
    }
}
