using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSwordButtonTutorial : TutorialStage
{
    public ClickSwordButtonTutorial()
    {
        _tutorialEvent = new TutorialButtonClickEvent(TutorialSceneSetup.CurrentScene.Text, "Sword");
    }
}
