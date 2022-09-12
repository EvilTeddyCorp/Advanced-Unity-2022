using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed = 500;
    Rigidbody2D rb;
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(7,7);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up*Speed);    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
        }

        this.gameObject.SetActive(false);
    }
    

}
