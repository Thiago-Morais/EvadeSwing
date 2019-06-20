using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public static Spawn Instance{get; private set;}
    #region Singleton
    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    #endregion
    
    public List<SyncObjectsToUse> syncObjectsToUse;
    [System.Serializable] public class SyncObjectsToUse
    {
        public string tag;
        public SyncObject syncInstance;
    }
    public void SpawnInstance()
    {
        
    }
}
