using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEndText : TutorialStage
{
    public TutorialEndText()
    {
        _tutorialEvent = new TutorialTextEvent(TutorialSceneSetup.CurrentScene.Text, "You've finished my tutorial! Now it's your turn to finish this game. Good luck!");
    }
}
