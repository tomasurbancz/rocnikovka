using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToMainMap : TutorialStage  
{
    public TeleportToMainMap()
    {
        _tutorialEvent = new TutorialChangeSceneEvent("Map");
    }
}
