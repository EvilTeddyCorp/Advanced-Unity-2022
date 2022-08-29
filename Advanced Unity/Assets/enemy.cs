using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;



public class enemy : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    public bool VisionHu = true;   // vision hukattu

    public void VisionFound()
    {
        Enemy.GetComponent<AIDestinationSetter>().target = Player.transform; 
        VisionHu = false;
    }
    private void Update()
    {
        if (!VisionHu)
        {
            Vector3 dir = Player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        }

    }





}
