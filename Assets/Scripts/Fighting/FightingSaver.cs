using UnityEngine;

public class FightingSaver : MonoBehaviour
{
    public void Save(int id)
    {
        Saver.SaveInt("FightingLevel", id);
    }
}
