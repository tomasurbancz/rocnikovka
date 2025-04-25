using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeTextTutorial : TutorialStage
{

    public WelcomeTextTutorial()
    {
        _tutorialEvent = new TutorialTextEvent(TutorialSceneSetup.CurrentScene.Text, "Hello, welcome to the game Swords & Souls Remake. I'll show you how the game works.");
    }
}
