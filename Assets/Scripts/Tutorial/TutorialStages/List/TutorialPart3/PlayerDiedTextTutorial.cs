using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiedTextTutorial : TutorialStage
{
    // Start is called before the first frame update
    public PlayerDiedTextTutorial()
    {
        _tutorialEvent = new TutorialTextEvent(TutorialSceneSetup.CurrentScene.Text, "Unfortunately, the enemy defeated you.");
    }
}
