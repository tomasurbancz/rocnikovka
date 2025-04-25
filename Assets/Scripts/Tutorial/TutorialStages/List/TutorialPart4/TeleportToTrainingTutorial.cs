using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToTrainingTutorial : TutorialStage
{
    public TeleportToTrainingTutorial()
    {
        _tutorialEvent = new TutorialChangeSceneEvent("Training");
    }
}
