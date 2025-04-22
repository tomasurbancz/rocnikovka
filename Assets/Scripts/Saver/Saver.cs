using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Saver
{
    public static void SaveInt(string name, int val)
    {
        PlayerPrefs.SetInt(name, val);
    }

    public static void SaveFloat(string name, float val)
    {
        PlayerPrefs.SetFloat(name, val);
    }

    public static void SaveString(string name, string val)
    {
        PlayerPrefs.SetString(name, val);
    }

    public static string GetString(string name)
    {
        return PlayerPrefs.GetString(name);
    }

    public static int GetInt(string name)
    {
        return PlayerPrefs.GetInt(name);
    }

    public static float GetFloat(string name)
    {
        return PlayerPrefs.GetFloat(name);
    }

    public static bool HasKey(string name)
    {
        return PlayerPrefs.HasKey(name);
    }

    public static void Save()
    {
        PlayerPrefs.Save();
    }
}
