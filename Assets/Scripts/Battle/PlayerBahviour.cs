using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBahviour : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Health and Mana Bars")]
    public HealthBarController healthBar;
    public ManaBarController manaBar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Constantly update player's health and mana bars.
        healthBar.SetValue(GameManager.Instance.playerHP);
        manaBar.SetValue(GameManager.Instance.playerMP);
        if(GameManager.Instance.playerHP <= 0)
        {
            GameManager.Instance.SceneChange("GameOver");
        }
    }
}
