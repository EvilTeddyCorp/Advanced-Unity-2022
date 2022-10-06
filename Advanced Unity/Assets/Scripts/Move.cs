using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector2 Velocity = Vector2.zero;
    private Transform Place;
    bool Moving = false;
    PathfindingManager pathfindingManager;

    private void Start()
    {
        pathfindingManager = GameObject.Find("A*").GetComponent<PathfindingManager>();
    }
    public void MoveTo(Transform To)
    {
        if(this.transform.position != To.transform.position)
        {
            Place = To;
            Moving = true;
        }
    }
    private void FixedUpdate()
    {
        if (Moving == true)
        {
            transform.position = Vector2.SmoothDamp(transform.position, Place.position, ref Velocity, 0.3f);
            pathfindingManager.RecalculateGraph(this.gameObject);
            if (this.transform.position == Place.position)
            {
                Debug.Log("finished");
                Moving = false;
            }
        }
        
    }

}
