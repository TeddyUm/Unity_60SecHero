using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_End : MonoBehaviour
{
    void Start()
    {
        SoundManager.Instance.Play("GameOverBGM");
    }

    // Go to mainmenu
    public void MainMenuButton()
    {
        SoundManager.Instance.Play("Button");
        SoundManager.Instance.Stop("GameOverBGM");
        GameManager.Instance.SceneChange("MainMenu");
    }

    // quit game
    public void QuitButton()
    {
        SoundManager.Instance.Play("Button");
        Application.Quit();
    }
}
