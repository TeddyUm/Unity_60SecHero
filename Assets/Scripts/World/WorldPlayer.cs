using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPlayer : MonoBehaviour
{
    // player move speed
    [SerializeField]
    public float speed;
    // player animator
    [SerializeField]
    private Animator playerAnim;
    // village out points
    [SerializeField]
    private GameObject VillageOutObj;
    [SerializeField]
    private GameObject Village2OutObj;
    [SerializeField]
    private GameObject Village3OutObj;

    private float h;
    private float v;
    private bool moving;

    void Start()
    {
        // player start position
        transform.position = GameManager.Instance.playerPosition;
        SoundManager.Instance.Play("MainGameBGM");
    }

    void Update()
    {
        if (!GameManager.Instance.isPaused)
        {
            // village out set position
            if (GameManager.Instance.VillageOut)
            {
                transform.position = VillageOutObj.transform.position;
                GameManager.Instance.VillageOut = false;
            }
            if (GameManager.Instance.Village2Out)
            {
                transform.position = Village2OutObj.transform.position;
                GameManager.Instance.Village2Out = false;
            }
            if (GameManager.Instance.Village3Out)
            {
                transform.position = Village3OutObj.transform.position;
                GameManager.Instance.Village3Out = false;
            }

            // player move function
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            gameObject.transform.Translate(new Vector2(h * Time.deltaTime * speed, v * Time.deltaTime * speed));

            // player animation
            playerAnim.SetFloat("MoveX", h);
            playerAnim.SetFloat("MoveY", v);

            GameManager.Instance.playerPosition = transform.position;


            // player level and EXP refresh
            if (GameManager.Instance.playerEXP >= GameManager.Instance.playerMaxEXP)
            {
                GameManager.Instance.playerLevel++;
                GameManager.Instance.playerDef += 2;
                GameManager.Instance.playerAtk += 3;
                GameManager.Instance.playerMagicAtk += 3;
                GameManager.Instance.playerHP = 100;
                GameManager.Instance.playerMP = 100;
                GameManager.Instance.playerEXP -= GameManager.Instance.playerMaxEXP;
            }

            // time limit decrease
            GameManager.Instance.time -= Time.deltaTime;

            // game over (time up)
            if (GameManager.Instance.time < 0)
            {
                GameManager.Instance.SceneChange("GameOver");
            }

            // Cheat EXP
            if(Input.GetKeyDown(KeyCode.X))
            {
                GameManager.Instance.playerEXP += 100;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Go to village
        if(collision.CompareTag("Village") && !GameManager.Instance.VillageOut)
        {
            GameManager.Instance.VillageIn = true;
            GameManager.Instance.SceneChange("Village");
        }
        else if (collision.CompareTag("Village2") && !GameManager.Instance.VillageOut)
        {
            GameManager.Instance.Village2In = true;
            GameManager.Instance.SceneChange("Village");
        }
        else if (collision.CompareTag("Village3") && !GameManager.Instance.VillageOut)
        {
            GameManager.Instance.Village3In = true;
            GameManager.Instance.SceneChange("Village");
        }
        // last battle
        else if (collision.CompareTag("Dungeon"))
        {
            SoundManager.Instance.Stop("MainGameBGM");
            EnemyManager.Instance.SettingEnemy(ENEMYTYPE.DEMON);
            GameManager.Instance.SceneChange("BattleScene");
        }
    }
    // checking player move status
    public bool GetPlayerIsMoving() 
    {
        if (Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f)
            moving = true;
        else
            moving = false;

        return moving;
    }
}
