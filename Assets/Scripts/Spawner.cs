using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawner", menuName = "Spawner/Spawner")]
public class Spawner : ScriptableObject
{
    public GameObject toSpawn;
    public uint amount;
    public Vector3 position;
    public float radius;
    
}
