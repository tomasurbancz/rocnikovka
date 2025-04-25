using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSwordTextTutorial : TutorialStage
{
    public ClickSwordTextTutorial()
    {
        _tutorialEvent = new TutorialTextEvent(TutorialSceneSetup.CurrentScene.Text, "Welcome to the training room! This is where you improve your attributes.");
    }
}
