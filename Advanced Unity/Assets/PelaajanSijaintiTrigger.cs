using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelaajanSijaintiTrigger : MonoBehaviour
{
    public GameObject Enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Enemy && Enemy.GetComponent<enemy>().VisionHu == true)
        {
            
            Enemy.GetComponent<enemy>().StartCoroutine("Unohtaminen");


        }

    }


}
