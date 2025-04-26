using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRetryTutorial : TutorialStage
{
    public ClickRetryTutorial()
    {
        _tutorialEvent = new TutorialButtonClickEvent(TutorialSceneSetup.CurrentScene.Text, "GoToMap", "Map");
    }
}
