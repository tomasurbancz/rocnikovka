using System.Collections.Generic;
using UnityEngine;


public class Tutorial : MonoBehaviour
{
    private List<TutorialStage> _tutorialStages = new List<TutorialStage>();
    private TutorialStage _currentTutorialStage;
    private float _setupCooldown = 0.1f;
    private bool _activated = false;
    public static int Id;
    public static bool CompletedTutorial;

    public void Start()
    {
        CompletedTutorial = HaveCompletedTutorial();
        Debug.Log(CompletedTutorial);
    }

    private void Activate()
    {
        _activated = true;
        _tutorialStages.Add(new WelcomeTextTutorial());
        _tutorialStages.Add(new ClickOnArenaTutorial());
        _tutorialStages.Add(new TeleportToArenaTutorial());

        _tutorialStages.Add(new WelcomeInArenaTutorial());
        _tutorialStages.Add(new WelcomeInArenaTutorial());
        _tutorialStages.Add(new ClickFightTutorial());
        _tutorialStages.Add(new ArenaFightTeleportTutorial());

        _tutorialStages.Add(new PlayerDieTutorial());
        _tutorialStages.Add(new PlayerDieTutorial());
        _tutorialStages.Add(new PlayerDiedTextTutorial());
        _tutorialStages.Add(new ClickRetryTutorial());
        _tutorialStages.Add(new TeleportToMainMap());

        _tutorialStages.Add(new ClickTrainingTextTutorial());
        _tutorialStages.Add(new ClickTrainingTextTutorial());
        _tutorialStages.Add(new ClickTrainingButtonTutorial());
        _tutorialStages.Add(new TeleportToTrainingTutorial());

        _tutorialStages.Add(new ClickSwordTextTutorial());
        _tutorialStages.Add(new ClickSwordTextTutorial());
        _tutorialStages.Add(new ClickSwordButtonTutorial());
        _tutorialStages.Add(new TeleportToSwordTrainingTutorial());

        _tutorialStages.Add(new SwordDestroyApplesTutorial());
        _tutorialStages.Add(new SwordDestroyApplesTutorial());
        _tutorialStages.Add(new TeleportToMainMap());

        _tutorialStages.Add(new TutorialEndText());
        _tutorialStages.Add(new TutorialEndText());
        NewStage();
    }

    private bool HaveCompletedTutorial()
    {
        return Saver.GetBool("LocalTutorialCompleted");
    }

    public void Update()
    {
        if (!CompletedTutorial)
        {
            if (_setupCooldown <= 0)
            {
                if (!_activated) Activate();
                _currentTutorialStage.Update();
                if(_currentTutorialStage.InstantlyMoveToNext())
                {
                    NewStage();
                }
            }
            else
            {
                _setupCooldown -= Time.deltaTime;
            }
        }
    }

    public void Click(string objectName)
    {
        if (!CompletedTutorial)
        {
            if (objectName.Equals("Map"))
            {
                if (_currentTutorialStage.IsCompleted())
                {
                    NewStage();
                }
            }
            else
            {
                _currentTutorialStage._tutorialEvent.Click(objectName);
            }
        }
    }

    private void NewStage()
    {
        if (Id >= _tutorialStages.Count) EndTutorial();
        else
        {
            _currentTutorialStage = _tutorialStages[Id];
            _currentTutorialStage.Activate();
            Id++;
        }
    }

    private void EndTutorial()
    {
        Saver.SaveBool("LocalTutorialCompleted", true);
        Saver.Save();
        Menu.ChangeTutorialScene("Map");
    }
}
