using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;



public class enemy : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    public GameObject Checkpoint;
    public bool VisionHu = true;   // vision hukattu

    public void VisionFound()
    {
        Enemy.GetComponent<AIDestinationSetter>().target = Player.transform; 
        VisionHu = false;
    }

    public void VisionLost()
    {
        VisionHu = true;
        // pit‰‰ teh‰ tohon se ett‰ player tiputtaa prefabin

        Enemy.GetComponent<AIDestinationSetter>().target = Checkpoint.transform;
    }

    private void Update()
    {
        if (!VisionHu)
        {
            Vector3 dir = Player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

            RaycastHit2D raycastH = Physics2D.Raycast(this.transform.position, dir);
            if (raycastH.collider.gameObject != Player)
            {
                VisionLost();
            }

        }

    }





}
