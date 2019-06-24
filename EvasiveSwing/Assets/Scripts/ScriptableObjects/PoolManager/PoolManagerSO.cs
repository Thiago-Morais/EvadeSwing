using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object Pool", menuName = "List/Pool Manager")]
public class PoolManagerSO : ScriptableObject
{
    [Header("NotesDatabase")]
    public List<InstanceInfo> objectsToSpawn;
}
