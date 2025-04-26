using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialTextEvent : TutorialEvent
{
    private float _cooldown = 0.1f;
    private string _currentText = "";
    private string _wantedText;
    private int _currentIndex = 0;
    private bool _running;
    private TMP_Text _text;
    private Image _background;
    private float direction = -0.3f;
    private bool _changeBackgroud;

    public TutorialTextEvent(TMP_Text text, string wantedText, bool changeBackground = true)
    {
        _text = text;
        _wantedText = wantedText;
        _running = true;
        _changeBackgroud = changeBackground;
        _background = TutorialSceneSetup.CurrentScene.Background;
    }

    private void PrintNewLetter()
    {
        _currentText += _wantedText.ToCharArray()[_currentIndex];
        _currentIndex++;
        //SoundManager.PlaySound("button");
        if (_currentIndex >= _wantedText.Length) _running = false;
        UpdateText();
    }
    
    private void UpdateText()
    {
        if(_running) _text.text = _currentText + "_";
        else _text.text = _currentText;
    }

    private void ChangeBackgroundColor()
    {
        float alpha = _background.color.a + direction * Time.deltaTime;
        if(alpha >= 1)
        {
            alpha = 0.99f;
            direction = -direction;
        }
        if(alpha <= 0.7f)
        {
            alpha = 0.71f;
            direction = -direction;
        }
        _background.color = _background.color.ChangeAlpha(alpha);
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
        else if(_changeBackgroud)
        {
            ChangeBackgroundColor();
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

    public override void DeleteChanges()
    {
        _background.color = _background.color.GetVisibleColor();
    }
}
