using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointPatrol : MonoBehaviour
{
    public GameObject NextCheckpoint;
    public GameObject Enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject == Enemy && Enemy.GetComponent<Pathfinding.AIDestinationSetter>().target == this.transform)
        {
            Invoke("TargetVaihto", 1);                
        }
    }
    public void TargetVaihto()
    {
        if (Enemy.GetComponent<enemy>().Unohdettu == true)
        {
            Enemy.GetComponent<Pathfinding.AIDestinationSetter>().target = NextCheckpoint.transform;
            Enemy.GetComponent<enemy>().Checkpoint = NextCheckpoint;
        }
    }





}
