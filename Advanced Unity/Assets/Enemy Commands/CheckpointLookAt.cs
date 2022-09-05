using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointLookAt : MonoBehaviour
{
    public int Rotation;
    public GameObject Enemy;
    public bool EnemyCollided;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == Enemy && Enemy.GetComponent<Pathfinding.AIPath>().reachedDestination == true && Enemy.GetComponent<enemy>().VisionHu == true) 
        {
            EnemyCollided = true; 
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyCollided = false;
    }
    void FixedUpdate()
    {
        if (EnemyCollided == true)
        {
            Enemy.transform.rotation = Quaternion.Lerp(Enemy.transform.rotation, Quaternion.Euler(0, 0, Rotation), 2 * Time.deltaTime);
        }
    }
}
