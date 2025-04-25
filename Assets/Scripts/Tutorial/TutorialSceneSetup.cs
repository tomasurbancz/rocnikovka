using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialSceneSetup : MonoBehaviour
{
    public TMP_Text Text;
    public Image Paper;
    public static TutorialSceneSetup CurrentScene;

    // Start is called before the first frame update
    void Start()
    {
        CurrentScene = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
