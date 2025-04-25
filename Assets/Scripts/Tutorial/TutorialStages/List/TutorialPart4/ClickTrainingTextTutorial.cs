using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTrainingTextTutorial : TutorialStage
{
    public ClickTrainingTextTutorial()
    {
        _tutorialEvent = new TutorialTextEvent(TutorialSceneSetup.CurrentScene.Text, "Unfortunately, you are too weak to beat this level. You will have to practice.");
    }
}
