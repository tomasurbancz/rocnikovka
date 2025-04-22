using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
    public Texture2D _pointerCursor;
    public Texture2D _handCursor;
    public Texture2D _disabledCursor;
    public Button _button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonEnter()
    {
        if(_button.interactable) Cursor.SetCursor(_handCursor, Vector2.zero, CursorMode.Auto);
        else Cursor.SetCursor(_disabledCursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnButtonLeave()
    {
        Cursor.SetCursor(_pointerCursor, Vector2.zero, CursorMode.Auto);
    }
}
