using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUi : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Peli sammutettu");
    }

    public void LoadLevel(string Level)
    {
        LevelManager.Instance.LoadLevel(Level);
    }
}
