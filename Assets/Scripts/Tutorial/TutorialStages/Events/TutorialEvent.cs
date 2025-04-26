using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TutorialEvent 
{
    public abstract bool IsPaperNeeded();
    public abstract void Update();
    public abstract bool IsCompleted();
    public abstract bool InstantlyMoveToNext();
    public abstract void Click(string objectName);
    public abstract void DeleteChanges();
}
