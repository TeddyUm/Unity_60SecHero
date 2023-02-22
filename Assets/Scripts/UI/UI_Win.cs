using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Win : MonoBehaviour
{
    void Start()
    {
        SoundManager.Instance.Play("WinBGM");
    }
    // go to mainmenu
    public void MainMenuButton()
    {
        SoundManager.Instance.Play("Button");
        SoundManager.Instance.Stop("WinBGM");
        GameManager.Instance.SceneChange("MainMenu");
    }
    // quit game
    public void QuitButton()
    {
        SoundManager.Instance.Play("Button");
        Application.Quit();
    }
}
