using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewEnemyData", menuName = "AdvancedUnity/Create New Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string EnemyName;
    public int MaxHealth = 100;
    public float RayRange = 20f;
    public GameObject PlayerSijaintiTallennus;
    public float CheckpointSlowdownDistance = 0.4f;
    public float PlayerSlowdownDistance = 5f;
    public float CheckpointEndReachedDistance = 0.2f;
    public float PlayerEndReachedDistance = 4f;
    public float VisionDelay = 1;
    public float AlertModeDelay = 5;
    public bool HiveMind;
    public int Health = 10;
    public float FirerateWait = 0.20f;
    public float BulletSpeed = 1200;
    public GameObject BulletPref;


}
