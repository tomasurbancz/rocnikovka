using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToSwordTrainingTutorial : TutorialStage
{
    public TeleportToSwordTrainingTutorial()
    {
        _tutorialEvent = new TutorialChangeSceneEvent("Sword");
    }
}
