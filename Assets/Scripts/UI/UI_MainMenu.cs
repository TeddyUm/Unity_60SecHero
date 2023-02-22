using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    // credit panel
    [SerializeField]
    private GameObject credit;
    // check credit panel toggle
    private bool isCredit;

    void Start()
    {
        SoundManager.Instance.Play("MainMenuBGM");
    }

    // game start button
    public void GameStart()
    {
        SoundManager.Instance.Play("Button");
        SoundManager.Instance.Stop("MainMenuBGM");
        // init data
        GameManager.Instance.playerHP = 100;
        GameManager.Instance.playerMP = 100;
        GameManager.Instance.playerAtkType = 0;
        GameManager.Instance.playerAtk = 10;
        GameManager.Instance.playerMagicAtk = 15;
        GameManager.Instance.playerDef = 5;
        GameManager.Instance.playerLevel = 1;
        GameManager.Instance.playerEXP = 0;
        GameManager.Instance.playerMaxEXP = 100;
        GameManager.Instance.time = 60.0f;
        GameManager.Instance.playerPosition = new Vector2(-3, 6);
        for(int i = 0; i < 12; i++)
        {
            GameManager.Instance.itemGetNum[i] = false;
        }
        GameManager.Instance.dayTimer = 0.7f;
        GameManager.Instance.maxWeatherTime = 10;
        GameManager.Instance.weatherTime = 0;
        GameManager.Instance.isSunrise = true;

        GameManager.Instance.SceneChange("WorldScene");
    }
    // load button
    public void LoadButton()
    {
        SoundManager.Instance.Play("Button");
        SoundManager.Instance.Stop("MainMenuBGM");
        SaveManager.Instance.Load();
        GameManager.Instance.SceneChange("WorldScene");
    }
    // credit button
    public void CreditButton()
    {
        if (!isCredit)
        {
            SoundManager.Instance.Play("Button");
            credit.SetActive(true);
            isCredit = true;
        }
        else
        {
            SoundManager.Instance.Play("Button");
            credit.SetActive(false);
            isCredit = false;
        }
    }
    // quit button
    public void QuitButton()
    {
        SoundManager.Instance.Play("Button");
        Application.Quit();
    }
}
