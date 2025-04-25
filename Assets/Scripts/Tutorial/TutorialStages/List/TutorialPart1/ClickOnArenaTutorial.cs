using UnityEngine;

public class ClickOnArenaTutorial : TutorialStage
{
    public ClickOnArenaTutorial()
    {
        _tutorialEvent = new TutorialButtonClickEvent(TutorialSceneSetup.CurrentScene.Text, "Arena");
    }
}
