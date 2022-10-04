using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public float RotationSpeed;
    public GameObject Player;
    public GameObject CollectedDiamond;
    public GameObject Barrel;
    private void Update()
    {
        transform.Rotate(0, 0, +RotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player) 
        {
            // pelaa ‰‰ni jos joskus aion teh‰
            this.gameObject.SetActive(false);
            CollectedDiamond.gameObject.SetActive(true);
            Player.GetComponent<FpsController>().enabled = false;
            Barrel.SetActive(false);

        }
    }
}
