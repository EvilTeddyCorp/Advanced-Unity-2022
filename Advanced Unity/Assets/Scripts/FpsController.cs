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
    int Ammo = 250;
    public int MaxAmmo = 250;
    bool Firing = false;
    private void Start()
    {
        Ammo = MaxAmmo;
        UIManager.Instance.UpdateAmmo(Ammo);
    }
    private void FixedUpdate()
    {
            if (Input.GetKey(KeyCode.Mouse0) && !Firing && Ammo > 0)
            {
            StartCoroutine(Shoot());
            }
    }
    IEnumerator Shoot() 
    {
        Firing = true;
        Ammo--;
        UIManager.Instance.UpdateAmmo(Ammo);
        Debug.Log("Shoot");
        Bullet = Instantiate(BulletPref,FirePoint.transform.position, this.transform.rotation);
        Bullet.GetComponent<BulletScript>().Speed = BulletSpeed;    
        yield return new WaitForSeconds(FirerateWait);
        Firing = false;
    }

}
