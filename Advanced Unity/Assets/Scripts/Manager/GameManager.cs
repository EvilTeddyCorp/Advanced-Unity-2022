using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    //public GameObject Player;

    bool isPaused = false;
    public void PauseGame()
    {
        if (isPaused)
            PauseGame(false);
        else
            PauseGame(true);

    }
    void PauseGame(bool t)
    {
        if (t)
        {
            Time.timeScale = 0;
            UIManager.Instance.ToggleMenu(true);
            isPaused = true;
            //Player.canMove = false;
        }
        else
        {
            Time.timeScale = 1;
            UIManager.Instance.ToggleMenu(false);
            isPaused = false;
            //Player.canMove = true;
        }

    }
}
