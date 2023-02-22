using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UI_World : MonoBehaviour
{
    [SerializeField]
    private Text timeText; // time limit text
    [SerializeField]
    private Text levelEXPText; // player EXP Level text
    [SerializeField]
    private Text statusText; // player status text
    [SerializeField]
    private GameObject optionPanel; // option panel
    [SerializeField]
    private GameObject statusPanel; // status panel
    [SerializeField]
    private GameObject savePanel; // save function panel
    [SerializeField]
    private Image playerHPGuage; // player HP guage
    [SerializeField]
    private Image playerMPGuage; // player MP guage    
    [SerializeField]
    private Slider volumeSlider; // Sound

    private bool isOption;
    private bool isStatus;

    void Update()
    {
        // time text print
        if (GameManager.Instance.time > 0)
            timeText.text = "Time: " + (int)GameManager.Instance.time;
        else
            timeText.text = "Time: " + 0;

        // guages value
        playerHPGuage.fillAmount = GameManager.Instance.playerHP / 100.0f;
        playerMPGuage.fillAmount = GameManager.Instance.playerMP / 100.0f;


        for(int i = 0; i < SoundManager.Instance.sounds.Length; i++)
        {
            SoundManager.Instance.sounds[i].Volumn = volumeSlider.value;
            SoundManager.Instance.sounds[i].SetVolumn();
        }

        // player EXP and level text
        levelEXPText.text = "Level " + GameManager.Instance.playerLevel + " (" + GameManager.Instance.playerEXP + " / " + GameManager.Instance.playerMaxEXP + ")";

    }

    public void StatusButton()
    {
        // player statud data and pause
        if (!isStatus)
        {
            SoundManager.Instance.Play("Button");
            statusText.text = "Player Atk: " + GameManager.Instance.playerAtk + "\n\nPlayer Def: " + GameManager.Instance.playerDef +
                "\n\nPlayer HP: " + GameManager.Instance.playerHP + " / 100" + "\n\nPlayer MP: " + GameManager.Instance.playerMP + " / 100";
            statusPanel.SetActive(true);
            isStatus = true;
            GameManager.Instance.isPaused = true;
        }
        // close status panel
        else
        {
            SoundManager.Instance.Play("Button");
            statusPanel.SetActive(false);
            isStatus = false;
            GameManager.Instance.isPaused = false;
        }
    }

    public void OptionButton()
    {
        // option on
        if (!isOption)
        {
            SoundManager.Instance.Play("Button");
            optionPanel.SetActive(true);
            isOption = true;
            GameManager.Instance.isPaused = true;
        }
       // option off
        else
        {
            SoundManager.Instance.Play("Button");
            optionPanel.SetActive(false);
            isOption = false;
            GameManager.Instance.isPaused = false;
        }
    }

    // save
    public void SaveButton()
    {
        SoundManager.Instance.Play("Button");
        SaveManager.Instance.Save();
        savePanel.SetActive(true);
        GameManager.Instance.isPaused = false;
    }
    // close save panel
    public void SaveClose()
    {
        SoundManager.Instance.Play("Button");
        savePanel.SetActive(false);
        GameManager.Instance.isPaused = false;
    }
    // go to mainmenu
    public void MainMenu()
    {
        SoundManager.Instance.Play("Button");
        SoundManager.Instance.Stop("MainGameBGM");
        GameManager.Instance.SceneChange("MainMenu");
        GameManager.Instance.isPaused = false;
    }
}

