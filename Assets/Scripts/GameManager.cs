using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{    
    // singleton design pattern
    #region singleton
    private static GameManager instance = null;

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

    public static GameManager Instance
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

    // player health point
    public int playerHP = 100;
    // player mana
    public int playerMP = 100;
    // player attack power
    public int playerAtkType = 0;
    public int playerAtk = 10;
    public int playerMagicAtk = 15;
    // player defence 
    public int playerDef = 5;
    // player level
    public int playerLevel = 1;
    // player experience
    public int playerEXP = 0;
    // player experience
    public int playerMaxEXP = 100;
    // time limit
    public float time = 60.0f;
    // IsPaused?
    public bool isPaused;
    // Village outpost
    public bool VillageIn;
    public bool VillageOut;
    // Village outpost
    public bool Village2In;
    public bool Village2Out;
    // Village outpost
    public bool Village3In;
    public bool Village3Out;
    // player position (world)
    public Vector2 playerPosition;
    // player position (world)
    public bool[] itemGetNum;
    // day timer
    public float dayTimer;
    public float maxWeatherTime;
    public float weatherTime;
    public bool isSunrise;
    public WEATHERSTATE weatherState;

    public PlayerAbilities pAbility;
    public int enemyAttacked = 0;
    public int attackTurn = 0;
    public bool bossSpawned = false;
    // scene changer
    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
