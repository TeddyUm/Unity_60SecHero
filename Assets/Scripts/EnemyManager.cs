using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENEMYTYPE
{
    GOBLIN,
    OGRE,
    DARKNIGHT,
    DEMON
}

public class EnemyManager : MonoBehaviour
{    
    // singleton design pattern
    #region singleton
    private static EnemyManager instance = null;

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

    public static EnemyManager Instance
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

    // ENEMY data
    public int atk;
    public int def;
    public int hp;
    public int exp;
    public ENEMYTYPE enemyType;
    public float encounterTime;

    // set enemy data (depend on type)
    public void SettingEnemy(ENEMYTYPE enemyType)
    {
        if (enemyType == ENEMYTYPE.GOBLIN)
        {
            SetEnemy(10, 0, 20, 30, ENEMYTYPE.GOBLIN);
        }
        else if (enemyType == ENEMYTYPE.OGRE)
        {
            SetEnemy(20, 0, 60, 40, ENEMYTYPE.OGRE);
        }
        else if (enemyType == ENEMYTYPE.DARKNIGHT)
        {
            SetEnemy(30, 10, 100, 50, ENEMYTYPE.DARKNIGHT);
        }
        else if (enemyType == ENEMYTYPE.DEMON)
        {
            SetEnemy(40, 5, 200, 500, ENEMYTYPE.DEMON);
            GameManager.Instance.bossSpawned = true;
        }
    }

    // set enemy
    public void SetEnemy(int _atk, int _def, int _hp, int _exp, ENEMYTYPE _enemyType)
    {
        atk = _atk;
        def = _def;
        hp = _hp;
        exp = _exp;
        enemyType = _enemyType;
    }
}
