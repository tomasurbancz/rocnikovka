using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSlider
{
    public Slider Slider;
    public TMP_Text ProgressText;
    public bool CompletedCurrentGoal = false;
    private int _progress;
    public int NextProgress;
    private int _lastProgress;

    public ScoreSlider(Slider slider, TMP_Text progressText, int progress, int nextProgress)
    {
        Slider = slider;
        ProgressText = progressText;
        _progress = progress;
        NextProgress = nextProgress;
    }

    public void ChangeGoal(int goalToAdd)
    {
        _lastProgress = NextProgress;
        NextProgress += goalToAdd;
    }

    public void UpdateProgress(int progress)
    {
        _progress = progress;
        if (progress == 0)
        {
            _lastProgress = 0;
            NextProgress = 10;
        }
        CompletedCurrentGoal = _progress >= NextProgress;
        UpdateBar();
    }

    private void UpdateBar()
    {
        Slider.value = ((float)(_progress - _lastProgress) / (NextProgress - _lastProgress));
        if (_progress != 0) ProgressText.text = "x" + _progress;
        else ProgressText.text = "";
    }
}
