using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Account account = Account.GetCurrentAccount();
        if(account != null)
        {
            Debug.Log("ACCOUNT: " + account.Name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string scene)
    {
        Debug.Log(Tutorial.CompletedTutorial);
        if(Tutorial.CompletedTutorial) SceneManager.LoadScene(scene);
    }

    public void ForceChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public static void ChangeTutorialScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
