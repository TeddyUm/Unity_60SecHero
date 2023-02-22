using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CloneManager : MonoBehaviour
{
    public GameObject enemy;

    //Instantiate 2 enemies
    private GameObject enemyOne, enemyTwo;

    //Timers for cloneManager.
    [SerializeField]
    private float timeRemaining = 2;
    private float textRemaining = 1;
    private float sysLeaveTime;
    
    [Header("System Text")]
    public Text textT;

    //Text Display
    [SerializeField]
    private int totalEXP;
    private bool textOn;
    private bool gameEnded;
    private string msg;

    [Header("Particle Systems")]
    public ParticleSystem meleeAtk;

    [Header("Backgrounds")]
    public GameObject[] backgrounds;
    // Start is called before the first frame update
    void Start()
    {
        textOn = false;
        gameEnded = false;
        sysLeaveTime = 3;
        totalEXP = 0;
        //Checks the type of the enemy, and instantiate up to 2 enemies based on random number.
        GameManager.Instance.attackTurn = 0;
        if (EnemyManager.Instance.enemyType == ENEMYTYPE.GOBLIN)
        {
            int randNum = Random.Range(1, 3);
            if (randNum == 1)
            {
                //Instantitate only 1 enemy
                instantitateEnemies(true, false);
            }
            if (randNum == 2)
            {
                //Instantitate 2 enemies
                instantitateEnemies(true, true);
            }
            backgrounds[0].gameObject.SetActive(true);
            backgrounds[1].gameObject.SetActive(false);
        }
        //If enemy type is either ogre or demon, then instantiate only 1 enemy.
        else if (EnemyManager.Instance.enemyType == ENEMYTYPE.OGRE || EnemyManager.Instance.enemyType == ENEMYTYPE.DARKNIGHT)
        {
            int randNum = Random.Range(1, 3);
            if (randNum == 1)
            {
                instantitateEnemies(true, false);
            }
            backgrounds[0].gameObject.SetActive(true);
            backgrounds[1].gameObject.SetActive(false);
        }
        else if(EnemyManager.Instance.enemyType == ENEMYTYPE.DEMON)
        {
            backgrounds[1].gameObject.SetActive(true);
            backgrounds[0].gameObject.SetActive(false);
        }

        getTotalEXP();
    }

    // Update is called once per frame
    void Update()
    {
        playerAttack();
        EnemyTurn(enemyTwo, 1,2);
        EnemyTurn(enemy, 2, 3);
        EnemyTurn(enemyOne, 3, 0);
        if (textOn)
        {
            
            if (textRemaining > 0)
            {
                textT.text = msg + " Damage.";
                textRemaining -= Time.deltaTime;
            }
            else
            {
                textT.text = "";
                textOn = false;
                textRemaining = 1;
            }

        }

        //Check all enemy dead
        if (enemy == null && enemyOne == null && enemyTwo == null)
        {
            if(!gameEnded)
                SoundManager.Instance.Play("BattleWin");
            gameEnded = true;
            SoundManager.Instance.Stop("BattleBGM");
        }

        //Displays how much EXP player gained.
        if (gameEnded)
        {
            if (sysLeaveTime > 0)
            {
                textT.text = "Player Gained : " + totalEXP + "EXP";
                sysLeaveTime -= Time.deltaTime;
            }
            else
            {
                textT.text = "";
                gameEnded = false;
                sysLeaveTime = 3;
                //Back to the World Scene.
                if(EnemyManager.Instance.enemyType != ENEMYTYPE.DEMON)
                    SceneManager.LoadScene("WorldScene");
                else
                    SceneManager.LoadScene("Win");
            }
        }
    }

    // Perform player's attack
    void playerAttack()
    {
        if (GameManager.Instance.enemyAttacked == 1 && enemyTwo != null)
        {
            damageinfPrint(enemyTwo, 1);
        }
        if (GameManager.Instance.enemyAttacked == 2 && enemy != null)
        {
            damageinfPrint(enemy, 2);
        }
        if (GameManager.Instance.enemyAttacked == 3 && enemyOne != null)
        {
            damageinfPrint(enemyOne, 3);
        }

    }

    // Perform's enemy's attack based on the attackturn.
    void EnemyTurn(GameObject specEnemy, int currentTurn, int nextTurn)
    {
        if (GameManager.Instance.attackTurn == currentTurn)
        {
            if (specEnemy != null)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                    if (specEnemy.GetComponent<EnemyData>().atk <= GameManager.Instance.playerDef)
                    {
                        GameManager.Instance.playerHP = GameManager.Instance.playerHP - 1;
                        textOn = true;
                        msg = "Player took 1";
                    }
                    else
                    {
                        GameManager.Instance.playerHP = GameManager.Instance.playerHP - (specEnemy.GetComponent<EnemyData>().atk - GameManager.Instance.playerDef);
                        textOn = true;
                        msg = "Player took " + (specEnemy.GetComponent<EnemyData>().atk - GameManager.Instance.playerDef);
                    }
                    meleeAtk.transform.position = new Vector3(-5.55f, -1.16f, 0);
                    SoundManager.Instance.Play("DamageTaken");
                    meleeAtk.Play();
                    GameManager.Instance.attackTurn = nextTurn;
                    timeRemaining = 2;
                }

            }
            else
            {
                GameManager.Instance.attackTurn = nextTurn;
            }
        }
    }

    //Calculates total exp earned from the battle.
    void getTotalEXP()
    {
        if(enemyOne == null && enemyTwo == null)
        {
            totalEXP += enemy.GetComponent<EnemyData>().exp;
        }
        else if(enemyTwo == null)
        {
            totalEXP += enemy.GetComponent<EnemyData>().exp + enemyOne.GetComponent<EnemyData>().exp;
        }
        else
        {
            totalEXP += enemy.GetComponent<EnemyData>().exp + enemyOne.GetComponent<EnemyData>().exp + enemyTwo.GetComponent<EnemyData>().exp;
        }
    }

    //Instantiating enemies function
    void instantitateEnemies(bool first, bool second)
    {
        if(first && second)
        {
            enemyOne = GameObject.Instantiate(enemy);
            enemyOne.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y - 2, 0);
            enemyTwo = GameObject.Instantiate(enemy);
            enemyTwo.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 2, 0);
        }
        else if(first && !second)
        {
            enemyOne = GameObject.Instantiate(enemy);
            enemyOne.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y - 2, 0);
        }
    }

    //Displays how much damage enemy got, and which enemy it is.
    void damageinfPrint(GameObject specEnemy, int enemyNum)
    {
        specEnemy.GetComponent<EnemyData>().damageInflicted();
        specEnemy.GetComponent<EnemyData>().printMsg(enemyNum);
    }
}
