using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject MenuPanel;
    public GameObject HUDPanel;
    public GameObject Ammo;
    public GameObject Health;
    private void Awake()
    {
        MenuPanel.SetActive(false);
        HUDPanel.SetActive(false);
    }

    public void ToggleMenu(bool t)
    {
        MenuPanel.SetActive(t);
        HUDPanel.SetActive(!t);
    }

    public void UpdateAmmo(int Amount)
    {
        Ammo.GetComponent<TMPro.TMP_Text>().text = "Ammo: " + Amount;
    }

    public void UpdateHealth(int Amount)
    {
        Health.GetComponent<TMPro.TMP_Text>().text = "Health: " + Amount;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
