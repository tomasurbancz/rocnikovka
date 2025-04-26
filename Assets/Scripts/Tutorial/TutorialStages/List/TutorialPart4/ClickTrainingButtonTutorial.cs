using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTrainingButtonTutorial : TutorialStage
{
    public ClickTrainingButtonTutorial()
    {
        _tutorialEvent = new TutorialButtonClickEvent(TutorialSceneSetup.CurrentScene.Text, "Training", "", 1);
    }
}
