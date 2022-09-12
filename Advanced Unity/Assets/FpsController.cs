using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsController : MonoBehaviour
{
    public GameObject BulletPref;
    public GameObject FirePoint;
    public float BulletSpeed = 1200;
    public float FirerateWait = 1;
    GameObject Bullet;
    bool Firing = false;
    private void FixedUpdate()
    {
            if (Input.GetKey(KeyCode.Mouse0) && !Firing)
            {
            StartCoroutine(Shoot());
            }
    }
    IEnumerator Shoot() 
    {
        Firing = true;
        Debug.Log("Shoot");
        Bullet = Instantiate(BulletPref,FirePoint.transform.position, this.transform.rotation);
        Bullet.GetComponent<BulletScript>().Speed = BulletSpeed;    
        yield return new WaitForSeconds(FirerateWait);
        Firing = false;
    }

}
