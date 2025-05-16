using UnityEngine;

public static class GamePreferences
{

    public static bool LevelAccess1
    {
        get => PlayerPrefs.GetInt("LevelAccess1", 1) == 1;
        set
        {
            PlayerPrefs.SetInt("LevelAccess1", value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static bool LevelAccess2
    {
        get => PlayerPrefs.GetInt("LevelAccess2", 0) == 1;
        set
        {
            PlayerPrefs.SetInt("LevelAccess2", value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static bool LevelAccess3
    {
        get => PlayerPrefs.GetInt("LevelAccess3", 0) == 1;
        set
        {
            PlayerPrefs.SetInt("LevelAccess3", value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static bool LevelAccess4
    {
        get => PlayerPrefs.GetInt("LevelAccess4", 0) == 1;
        set
        {
            PlayerPrefs.SetInt("LevelAccess4", value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static bool LevelAccess5
    {
        get => PlayerPrefs.GetInt("LevelAccess5", 0) == 1;
        set
        {
            PlayerPrefs.SetInt("LevelAccess5", value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static bool LevelAccess6
    {
        get => PlayerPrefs.GetInt("LevelAccess6", 0) == 1;
        set
        {
            PlayerPrefs.SetInt("LevelAccess6", value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static bool LevelAccess7
    {
        get => PlayerPrefs.GetInt("LevelAccess7", 0) == 1;
        set
        {
            PlayerPrefs.SetInt("LevelAccess7", value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static bool LevelAccess8
    {
        get => PlayerPrefs.GetInt("LevelAccess8", 0) == 1;
        set
        {
            PlayerPrefs.SetInt("LevelAccess8", value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static bool LevelAccess9
    {
        get => PlayerPrefs.GetInt("LevelAccess9", 0) == 1;
        set
        {
            PlayerPrefs.SetInt("LevelAccess9", value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static bool LevelAccess10
    {
        get => PlayerPrefs.GetInt("LevelAccess10", 0) == 1;
        set
        {
            PlayerPrefs.SetInt("LevelAccess10", value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

}