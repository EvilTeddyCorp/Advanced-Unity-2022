using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 50;
    public int CurrentHealth;
    private void Start()
    {
        CurrentHealth = MaxHealth;
        UIManager.Instance.UpdateHealth(CurrentHealth);
    }
    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        UIManager.Instance.UpdateHealth(CurrentHealth);
        if (CurrentHealth <= 0)
        {
            this.GetComponent<Movement>().enabled = false;
            this.GetComponent<FpsController>().enabled = false;
            UIManager.Instance.Lose();
        }
    }
}


