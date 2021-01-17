using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public static int coins;
    

    void Awake()
    {
        DontDestroyOnLoad(this);
        LoadAllData();
    }

    private void LoadAllData()
    {
        coins = GetPreference("coins_value", 0);
    }

    public static void SaveCoins(int _coins)
    {
        coins += _coins;
        SavePreference("coins_value", coins);
    }


    private static int GetPreference(string key, int defaultValue)
    {
        if (!PlayerPrefs.HasKey(key)) return defaultValue;
        return PlayerPrefs.GetInt(key);
    }

    private static void SavePreference(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
}
