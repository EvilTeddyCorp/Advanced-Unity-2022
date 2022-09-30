using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth;
    public GameObject Weakpoint;
    // Start is called before the first frame update


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            this.gameObject.SetActive(false);
            Weakpoint.SetActive(false);
            this.GetComponentInParent<MeshVision>().enabled = false;
            this.GetComponentInParent<MeshRenderer>().enabled = false;
            
        }
    }
}
