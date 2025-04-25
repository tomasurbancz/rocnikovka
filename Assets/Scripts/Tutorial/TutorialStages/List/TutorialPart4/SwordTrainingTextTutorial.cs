using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrainingTextTutorial : TutorialStage
{
    public SwordTrainingTextTutorial()
    {
        _tutorialEvent = new TutorialTextEvent(TutorialSceneSetup.CurrentScene.Text, "Use the W, S, D keys to break apples. Use the A key to catch stars.");
    }
}
