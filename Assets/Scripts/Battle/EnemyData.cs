using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyData : MonoBehaviour
{
    [SerializeField]

    [Header("Enemy Stats")]
    public int atk;
    public int def;
    public int hp;
    public int exp;

    [Header("Enemy Timer")]

    public float timeRemaining = 2;

    [Header("Enemy Health Bar")]
    public EnemyHealthBarController healthBar;

    [Header("System Text")]
    public Text textT;

    //Checkers, and printing messages / its time.
    [SerializeField]
    private bool textOn;
    private float textRemaining;
    private string msg;
    // Start is called before the first frame update
    void Start()
    {
        //Set all enemy's stats to given instance's stats
        atk = EnemyManager.Instance.atk;
        def = EnemyManager.Instance.def;
        hp = EnemyManager.Instance.hp;
        exp = EnemyManager.Instance.exp;

        //Display no msg for now
        msg = "";
        //Sets timer for the msg
        textRemaining = 1;
    }

    // Update is called once per frame
    void Update()
    {

        //Sets health bar status
        healthBar.SetValue(hp);

        //If the enemy has less or equal to 0 hp, destroy the enemy.
        if(hp <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.playerEXP = GameManager.Instance.playerEXP + exp;
        }

        // Print system text displaying either enemy has taken the damage or has fallen for 1 second. Then reset
        if (textOn)
        {

            if (textRemaining > 0)
            {
                textT.text = msg;
                textRemaining -= Time.deltaTime;
            }
            else
            {
                textT.text = "";
                textOn = false;
                textRemaining = 1;
            }

        }
    }

    //Set and updates enemy's hp when they are inflicted damage.
    public void damageInflicted()
    {
        hp = hp - (GameManager.Instance.playerAtkType - def);
        GameManager.Instance.enemyAttacked = 0;
    }

    //Displays specific message for 1 second
    public void printMsg(int enemyNum)
    {
        textOn = true;
        if (hp > 0)
        {
            msg = EnemyManager.Instance.enemyType + " " + enemyNum + " took " + (GameManager.Instance.playerAtkType - def).ToString() + " Damage.";
        }
        else
        {
            msg = EnemyManager.Instance.enemyType + " " + enemyNum + " has fallen.";
        }
    }
}
