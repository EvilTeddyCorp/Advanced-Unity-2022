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
<<<<<<< Updated upstream
    LayerMask Mask;
    public float RayRange = 20f; 
    private void Start()
    {
        Mask = LayerMask.GetMask("Wall", "player");
=======
    Vector3 Dir;
    LayerMask Mask;

    private void Start()
    {
        Mask = LayerMask.GetMask("player", "Wall");
    }
    public void VisionFound()
    {
        Enemy.GetComponent<AIDestinationSetter>().target = Player.transform;
     
        VisionHu = false;
>>>>>>> Stashed changes
    }
    public void VisionFound() // mesh vision kutsuu tän ku se osuu pelaajaan
    {
<<<<<<< Updated upstream
                //mesh vision scriptissä on testi että visionhu == true
            Enemy.GetComponent<AIDestinationSetter>().target = Player.transform;
            VisionHu = false;
        
    }
=======
        Debug.Log("Vision LOst");

        VisionHu = true;
        // pitää tehä tohon se että player tiputtaa prefabin
>>>>>>> Stashed changes

    public IEnumerator VisionLost()
    {
        
        yield return new WaitForSeconds(1);
        Instantiate(PlayerSijaintiTallennus, Player.transform.position, Player.transform.rotation); ;
        Enemy.GetComponent<AIDestinationSetter>().target = Checkpoint.transform;
<<<<<<< Updated upstream
        
=======
       
>>>>>>> Stashed changes
    }



    private void Update()
    {
        if (VisionHu == false) // jos vihollinen näkee pelaajan
        {
<<<<<<< Updated upstream
            Vector3 dir = Player.transform.position - transform.position; 
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);   // vihollinen katsoo pelaajaa

           
            RaycastHit2D RaycastH = Physics2D.Raycast(transform.position, dir, RayRange, Mask);
            if (RaycastH.collider == null || RaycastH.collider.gameObject.name != Player.name )    // raycast testaa että onko pelaajan ja vihollisen välissä jotain
=======
            Dir = Player.transform.position - transform.position;
            float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        }
        
    }
    private void FixedUpdate()  
    {
        if (!VisionHu)
        {
            RaycastHit2D raycastH = Physics2D.Raycast(this.transform.position, Dir, Mathf.Infinity, Mask);

            if (raycastH.collider.gameObject != Player || raycastH.collider == null)  // seinä vihollisen ja pelaajan välissä
>>>>>>> Stashed changes
            {
                VisionHu = true;
                Debug.Log("tag"); // ei toimi lol
            }
        }
    }






}
