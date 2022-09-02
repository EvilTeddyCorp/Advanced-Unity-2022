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
            StartCoroutine("TargetVaihto");            
        }
    }
    public IEnumerator TargetVaihto()
    {
        yield return new WaitForSeconds(1);
        while (Enemy.GetComponent<enemy>().Unohdettu == false) // wait until unohdettu == true
        { 
            yield return null;
        }
        Debug.Log("while passed");
        Enemy.GetComponent<Pathfinding.AIDestinationSetter>().target = NextCheckpoint.transform;
        Enemy.GetComponent<enemy>().Checkpoint = NextCheckpoint;
        
    }





}
