using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite goblinSprite, ogreSprite, devilSprite, darkKnightSprite;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(EnemyManager.Instance.enemyType == ENEMYTYPE.GOBLIN)
        {
            spriteRenderer.sprite = goblinSprite;

        }
        else if (EnemyManager.Instance.enemyType == ENEMYTYPE.OGRE)
        {
            spriteRenderer.sprite = ogreSprite;

        }
        else if (EnemyManager.Instance.enemyType == ENEMYTYPE.DEMON)
        {
            spriteRenderer.sprite = devilSprite;

        }
        else if (EnemyManager.Instance.enemyType == ENEMYTYPE.DARKNIGHT)
        {
            spriteRenderer.sprite = darkKnightSprite;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
