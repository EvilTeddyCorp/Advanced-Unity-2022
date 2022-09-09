using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PathfindingManager : Singleton<PathfindingManager>
{
    public AstarPath Pathfinder;

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder = GetComponent<AstarPath>();    
    }

    public void RecalculateGraph(GameObject area) // A* on ihan liian k‰tev‰. T‰‰ p‰ivitt‰‰ graphin tietylt‰ alueelta
    {
        Debug.Log("Recalculate graph");
        var guo = new GraphUpdateObject(area.GetComponent<Collider2D>().bounds); 
        guo.updatePhysics = true;
        AstarPath.active.UpdateGraphs(guo);
    }



}
