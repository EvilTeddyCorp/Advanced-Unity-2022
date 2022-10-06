using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;



public class enemy : MonoBehaviour
{
    public EnemyData enemyData;
    public HiveMindSystem HiveMindSystem;
    public GameObject Player;
    GameObject Enemy;
    public GameObject Fov;
    public GameObject Checkpoint;
    public bool VisionHu = true;   // vision hukattu
    public bool Rotation = true;
    public bool Unohdettu = true;
    LayerMask Mask;
    Vector3 Dir;
    GameObject PlayerSijainti;

    // kannattaaa laittaa eri pathfinding sensitivity enemyille 

    bool Executing = false;
    bool ExecutingFov = false;

    public GameObject FirePoint;
    GameObject Bullet;
    bool Firing = false;


        
    
        private void Start()
    {
        
        Enemy = this.gameObject;
        Mask = LayerMask.GetMask("Wall", "player", "IgnoreAstarpath");

        Enemy.GetComponent<AIDestinationSetter>().target = Checkpoint.transform;
        Enemy.GetComponent<AIPath>().slowdownDistance = enemyData.CheckpointSlowdownDistance;
        Enemy.GetComponent<AIPath>().endReachedDistance = enemyData.CheckpointEndReachedDistance;
        Enemy.GetComponent<EnemyHealth>().currentHealth = enemyData.Health;
        
    }
    public void VisionFound(bool ensimmainen) // mesh vision kutsuu t�n ku se osuu pelaajaan
    {
        if(enemyData.HiveMind == true && ensimmainen)
        {
            HiveMindSystem.HiveMindHunt();
        }
        Rotation = true;
        if (ExecutingFov)
        {
            StopCoroutine(Unohtaminen());
        }
        if (Executing)
        {
            StopCoroutine(VisionLost());
        }
        if (VisionHu == true)
        {
            Unohdettu = false;
            Fov.GetComponent<MeshVision>().haluttufov = 120;
            Enemy.GetComponent<AIDestinationSetter>().target = Player.transform;
            Enemy.GetComponent<AIPath>().slowdownDistance = enemyData.PlayerSlowdownDistance;
            Enemy.GetComponent<AIPath>().endReachedDistance = enemyData.PlayerEndReachedDistance;

            VisionHu = false;
        }

    }

    public IEnumerator VisionLost()
    {
       
        Debug.Log("VisionLost started");
        Executing = true;
        Enemy.GetComponent<AIPath>().slowdownDistance = enemyData.CheckpointSlowdownDistance;
        Enemy.GetComponent<AIPath>().endReachedDistance = enemyData.CheckpointEndReachedDistance;

        yield return new WaitForSeconds(enemyData.VisionDelay);
        if (!VisionHu)
        {
            if (PlayerSijainti != null) GameObject.Destroy(PlayerSijainti);
            PlayerSijainti = Instantiate(enemyData.PlayerSijaintiTallennus, Player.transform.position, Player.transform.rotation);
            PlayerSijainti.GetComponent<PelaajanSijaintiTrigger>().Enemy = this.gameObject;
            Enemy.GetComponent<AIDestinationSetter>().target = PlayerSijainti.transform;
            Debug.Log("VisionLost ended");

            VisionHu = true;
            Executing = false;
        }
    }

    private IEnumerator Unohtaminen()
    {
        ExecutingFov = true;
        yield return new WaitForSeconds(enemyData.AlertModeDelay);
        if (VisionHu == true)
        {
            Fov.GetComponent<MeshVision>().haluttufov = 45;
            Enemy.GetComponent<AIDestinationSetter>().target = Checkpoint.transform;
        }
        Unohdettu = true;
        ExecutingFov =false;
    }



    private void Update()
    {
        if (VisionHu == false && Rotation == true) // jos vihollinen n�kee pelaajan
        {
            Dir = Player.transform.position - transform.position;
            float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);   // vihollinen katsoo pelaajaa
        }

        if (!VisionHu)
        {
            RaycastHit2D RaycastH = Physics2D.Raycast(transform.position, Dir, enemyData.RayRange, Mask);
            if (RaycastH.collider == null || RaycastH.collider.gameObject != Player)    // raycast testaa ett� onko pelaajan ja vihollisen v�liss� jotain
            {
                Rotation = false;
               
                if (Executing != true)
                {
                    StartCoroutine(VisionLost());
                }
                else
                {
                    StopCoroutine(VisionLost());
                }
                if (ExecutingFov == true)
                {
                    StopCoroutine(Unohtaminen());
                }
            }
            else if (!Firing)
            {
                Rotation = true;
                StartCoroutine(Shoot());
            }


        }
        

    }

    IEnumerator Shoot()
    {
        Firing = true;
        Bullet = Instantiate(enemyData.BulletPref, FirePoint.transform.position, this.transform.rotation);
        Bullet.GetComponent<EnemyBulletScript>().Speed = enemyData.BulletSpeed;
        Bullet.GetComponent<EnemyBulletScript>().Player = Player;
        yield return new WaitForSeconds(enemyData.FirerateWait);
        Firing = false;
    }

}
