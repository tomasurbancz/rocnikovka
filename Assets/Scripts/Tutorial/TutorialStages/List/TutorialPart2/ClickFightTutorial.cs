using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFightTutorial : TutorialStage
{
    public ClickFightTutorial()
    {
        _tutorialEvent = new TutorialButtonClickEvent(TutorialSceneSetup.CurrentScene.Text, "Level 1");
        //Saver.SaveInt("");
    }
}
