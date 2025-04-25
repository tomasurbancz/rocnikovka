using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToArenaTutorial : TutorialStage
{
    public TeleportToArenaTutorial()
    {
        _tutorialEvent = new TutorialChangeSceneEvent("Arena");
    }
}
