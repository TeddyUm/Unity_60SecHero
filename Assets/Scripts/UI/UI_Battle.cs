using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Battle : MonoBehaviour
{
    [Header("System Text")]
    public Text textT;

    [SerializeField]
    private bool textOn;
    private float textRemaining = 1;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.Play("BattleBGM");
    }

    // Update is called once per frame
    void Update()
    {
        if (textOn)
        {

            if (textRemaining > 0)
            {
                textT.text = "You Cannot Run.";
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

    public void WorldScene()
    {
        //If the enemy's type is not Demon (Last Boss) then player is able to run away from the monsters.
        if (EnemyManager.Instance.enemyType != ENEMYTYPE.DEMON)
        {
            SoundManager.Instance.Stop("BattleBGM");
            GameManager.Instance.SceneChange("WorldScene");
        }
        //If the enemy is Demon, player cannot run away and displays a text on System Text.
        else
        {
            textOn = true;
        }
    }
}
