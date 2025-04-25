using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeInArenaTutorial : TutorialStage
{
    public WelcomeInArenaTutorial()
    {
        _tutorialEvent = new TutorialTextEvent(TutorialSceneSetup.CurrentScene.Text, "This is the arena. Here you will fight against enemies.");
    }
}
