using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveMindSystem : MonoBehaviour
{
    public enemy[] Enemies;

    public void HiveMindHunt()
    {
        foreach(enemy Enemy in Enemies)
        {
            Enemy.VisionFound(false);
        }
    }
}
