using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    [SerializeField]
    private int atk;
    [SerializeField]
    private int def;
    [SerializeField]
    private int hp;
    [SerializeField]
    private int exp;
    [SerializeField]
    private ENEMYTYPE enemyType;

    // enemy data setting
    public void SetEnemy(int _atk, int _def, int _hp, int _exp, ENEMYTYPE _enemyType)
    {
        atk = _atk;
        def = _def;
        hp = _hp;
        exp = _exp;
        enemyType = _enemyType;
    }
}
