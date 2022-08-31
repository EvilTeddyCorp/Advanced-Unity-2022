using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;



public class enemy : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    public GameObject Checkpoint;
    public GameObject PlayerSijaintiTallennus;
    public bool VisionHu = true;   // vision hukattu
    LayerMask Mask;
    public float RayRange = 20f; 
    private void Start()
    {
        Mask = LayerMask.GetMask("Wall", "player");
    }
    public void VisionFound() // mesh vision kutsuu tän ku se osuu pelaajaan
    {
                //mesh vision scriptissä on testi että visionhu == true
            Enemy.GetComponent<AIDestinationSetter>().target = Player.transform;
            VisionHu = false;
        
    }

    public IEnumerator VisionLost()
    {
        
        yield return new WaitForSeconds(1);
        Instantiate(PlayerSijaintiTallennus, Player.transform.position, Player.transform.rotation); ;
        Enemy.GetComponent<AIDestinationSetter>().target = Checkpoint.transform;
        
    }



    private void Update()
    {
        if (VisionHu == false) // jos vihollinen näkee pelaajan
        {
            Vector3 dir = Player.transform.position - transform.position; 
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);   // vihollinen katsoo pelaajaa

           
            RaycastHit2D RaycastH = Physics2D.Raycast(transform.position, dir, RayRange, Mask);
            if (RaycastH.collider == null || RaycastH.collider.gameObject.name != Player.name )    // raycast testaa että onko pelaajan ja vihollisen välissä jotain
            {
                VisionHu = true;
                Debug.Log("tag"); // ei toimi lol
            }

        }

    }





}
