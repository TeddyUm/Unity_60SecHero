using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    #region singleton
    private static SaveManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static SaveManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    #endregion

    // player position (world)
    public bool[] itemGetNum;


    // Save Function
    public void Save()
    {
        PlayerPrefs.SetInt("PlayerHP", GameManager.Instance.playerHP);
        PlayerPrefs.SetInt("PlayerMP", GameManager.Instance.playerMP);
        PlayerPrefs.SetInt("PlayerAtk", GameManager.Instance.playerAtk);
        PlayerPrefs.SetInt("PlayerDef", GameManager.Instance.playerDef);
        PlayerPrefs.SetInt("PlayerEXP", GameManager.Instance.playerEXP);
        PlayerPrefs.SetInt("PlayerDef", GameManager.Instance.playerMaxEXP);
        PlayerPrefs.SetInt("PlayerLevel", GameManager.Instance.playerLevel);
        PlayerPrefs.SetFloat("DayTimer", GameManager.Instance.dayTimer);
        PlayerPrefs.SetFloat("MaxWeatherTime", GameManager.Instance.maxWeatherTime);
        PlayerPrefs.SetFloat("WeatherTime", GameManager.Instance.weatherTime);

        for (int i = 0; i < 12; i++)
        {
            SetBool("Item" + i, GameManager.Instance.itemGetNum[i]);
        }
        SetBool("IsSunrise", GameManager.Instance.isSunrise);

        SetVector3("playerPosition", GameManager.Instance.playerPosition);
    }

    // Load Function
    public void Load()
    {
        GameManager.Instance.playerHP = PlayerPrefs.GetInt("PlayerHP");
        GameManager.Instance.playerMP = PlayerPrefs.GetInt("PlayerMP");
        GameManager.Instance.playerAtk = PlayerPrefs.GetInt("PlayerAtk");
        GameManager.Instance.playerDef = PlayerPrefs.GetInt("PlayerDef");
        GameManager.Instance.playerEXP = PlayerPrefs.GetInt("PlayerEXP");
        GameManager.Instance.playerMaxEXP = PlayerPrefs.GetInt("PlayerDef");
        GameManager.Instance.playerLevel = PlayerPrefs.GetInt("PlayerLevel");
        GameManager.Instance.dayTimer = PlayerPrefs.GetFloat("DayTimer");
        GameManager.Instance.maxWeatherTime = PlayerPrefs.GetFloat("MaxWeatherTime");
        GameManager.Instance.weatherTime = PlayerPrefs.GetFloat("WeatherTime");

        for (int i = 0; i < 12; i++)
        {
            GameManager.Instance.itemGetNum[i] = GetBool("Item" + i);
        }
        GameManager.Instance.isSunrise = GetBool("IsSunrise");

        GameManager.Instance.playerPosition = GetVector3("playerPosition");
    }

    // Save bool variable
    public static void SetBool(string key, bool value)
    {
        if (value)
            PlayerPrefs.SetInt(key, 1);
        else
            PlayerPrefs.SetInt(key, 0);
    }
    // Load bool variable
    public static bool GetBool(string key)
    {
        int value = PlayerPrefs.GetInt(key);
        if (value == 1)
            return true;

        else
            return false;
    }
    // save vector
    public static void SetVector3(string key, Vector3 value)
    {
        PlayerPrefs.SetFloat(key + "X", value.x);
        PlayerPrefs.SetFloat(key + "Y", value.y);
        PlayerPrefs.SetFloat(key + "Z", value.z);

    }
    // load vector
    public static Vector3 GetVector3(string key)
    {
        Vector3 v3 = Vector3.zero;
        v3.x = PlayerPrefs.GetFloat(key + "X");
        v3.y = PlayerPrefs.GetFloat(key + "Y");
        v3.z = PlayerPrefs.GetFloat(key + "Z");
        return v3;
    }
}
