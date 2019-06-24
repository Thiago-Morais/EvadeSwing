using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object Pool", menuName = "List/Pool of Objects")]
public class ObjectsListSO : ScriptableObject
{
    [Header("NotesDatabase")]
    public ItemDatabase itemDB;
}
