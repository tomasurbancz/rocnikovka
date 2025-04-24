using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrainingLeaveButton : MonoBehaviour
{
    public Image Glow;

    void Start()
    {
        Debug.Log("TEST");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHover()
    {
        Glow.color = Glow.color.ChangeAlpha(0.4f);
    }

    public void OnUnHover()
    {
        Glow.color = Glow.color.GetTransparentColor();
    }

    public void Leave()
    {
        SceneManager.LoadScene("Training");
    }
}
