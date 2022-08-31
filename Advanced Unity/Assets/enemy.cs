using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;



public class enemy : MonoBehaviour
{
    public EnemyData enemyData;

    public GameObject Player;
    GameObject Enemy;
    public GameObject Fov;
    public GameObject Checkpoint;
    public bool VisionHu = true;   // vision hukattu
    public bool Rotation = true;
    LayerMask Mask;
    Vector3 Dir;
    GameObject PlayerSijainti;

    bool Executing = false;
    bool ExecutingFov = false;

    private void Start()
    {
        Enemy = this.gameObject;
        Mask = LayerMask.GetMask("Wall", "player");

        Enemy.GetComponent<AIDestinationSetter>().target = Checkpoint.transform;
        Enemy.GetComponent<AIPath>().slowdownDistance = enemyData.CheckpointSlowdownDistance;
        Enemy.GetComponent<AIPath>().endReachedDistance = enemyData.CheckpointEndReachedDistance;
    }
    public void VisionFound() // mesh vision kutsuu tän ku se osuu pelaajaan
    {
        Rotation = true;
        if (ExecutingFov)
        {
            StopCoroutine(Unohtaminen());
        }
        if (Executing)
        {
            StopCoroutine(VisionLost());
            Debug.Log("Stopping Coroutine");
        }
        if (VisionHu == true)
        {
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
        
        PlayerSijainti = Instantiate(enemyData.PlayerSijaintiTallennus, Player.transform.position, Player.transform.rotation);
        PlayerSijainti.GetComponent<PelaajanSijaintiTrigger>().Enemy = this.gameObject;
        Enemy.GetComponent<AIDestinationSetter>().target = PlayerSijainti.transform;
        Debug.Log("VisionLost ended");

        VisionHu = true;
        Executing = false;
    }

    private IEnumerator Unohtaminen()
    {
        ExecutingFov = true;
        yield return new WaitForSeconds(enemyData.AlertModeDelay);
        Fov.GetComponent<MeshVision>().haluttufov = 45;
        Enemy.GetComponent<AIDestinationSetter>().target = Checkpoint.transform;
        ExecutingFov =false;

    }



    private void Update()
    {
        if (VisionHu == false && Rotation == true) // jos vihollinen näkee pelaajan
        {
            Dir = Player.transform.position - transform.position;
            float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);   // vihollinen katsoo pelaajaa
        }

        if (!VisionHu)
        {
            RaycastHit2D RaycastH = Physics2D.Raycast(transform.position, Dir, enemyData.RayRange, Mask);
            if (RaycastH.collider == null || RaycastH.collider.gameObject != Player)    // raycast testaa että onko pelaajan ja vihollisen välissä jotain
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
            else
            {
                Rotation = true;
               
            }
        }

    }
    private void FixedUpdate()
    {



    }





}
