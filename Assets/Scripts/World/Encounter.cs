using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    // player
    private WorldPlayer player;
    //encounter time
    [SerializeField]
    private float minEnouctTime;
    [SerializeField]
    private float maxEnouctTime;

    void Start()
    {
        player = FindObjectOfType<WorldPlayer>();
    }

    void Update()
    {
        // is player moving encounter time decrease
        if(player.GetPlayerIsMoving())
        {
            EnemyManager.Instance.encounterTime -= Time.deltaTime;
        }
        
        // encounter timer is 0, go to battle
        if (EnemyManager.Instance.encounterTime < 0)
        {
            // reset timer (random)
            EnemyManager.Instance.encounterTime = Random.Range(minEnouctTime, maxEnouctTime);

            //setting battle enemy (basic)
            if(GameManager.Instance.playerLevel < 3)
            {
                EnemyManager.Instance.SettingEnemy(ENEMYTYPE.GOBLIN);
            }
            //setting battle enemy (advanced)
            else if (GameManager.Instance.playerLevel >= 3 && GameManager.Instance.playerLevel < 6)
            {
                int range;
                range = Random.Range(0, 10);
                if (range > 5)
                {
                    EnemyManager.Instance.SettingEnemy(ENEMYTYPE.GOBLIN);
                }
                else
                {
                    EnemyManager.Instance.SettingEnemy(ENEMYTYPE.OGRE);
                }
            }
            //setting battle enemy (most powerful)
            else
            {
                int range;
                range = Random.Range(0, 10);
                if (range > 5)
                {
                    EnemyManager.Instance.SettingEnemy(ENEMYTYPE.OGRE);
                }
                else
                {
                    EnemyManager.Instance.SettingEnemy(ENEMYTYPE.DARKNIGHT);
                }
            }
            // go to battle scene
            SoundManager.Instance.Stop("MainGameBGM");
            GameManager.Instance.SceneChange("BattleScene");
        }
    }
}
