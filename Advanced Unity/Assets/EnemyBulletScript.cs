using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public GameObject Player;
    public float Speed = 2;
    Rigidbody2D rb;
    bool Rotating = true;
    public float RotateSpeed = 0.01f;
    public float RotateTime = 1f;

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(9, 2);
        Physics2D.IgnoreLayerCollision(2, 2);
        rb = GetComponent<Rigidbody2D>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player)
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }

        this.gameObject.SetActive(false);
    }
    void Update()
    {

        if (Rotating)
        {
            rb.velocity = transform.up * Speed;
            Vector3 dir = Player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle - 90), RotateSpeed * Time.deltaTime);
            StartCoroutine("disablerotate");
        }

    }
    IEnumerator disablerotate()
    {
        yield return new WaitForSeconds(RotateTime);
        Rotating = false;
    }
}
