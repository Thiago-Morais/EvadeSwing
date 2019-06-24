using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class SyncManager : MonoBehaviour
{
    public static SyncManager Instance;
    #region Singleton
    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    #endregion
    public List<ObjectSpawnInfo> objectsToSpawn;
    public List<PoolManagerInfo> poolManagerList;
    [System.Serializable] public class PoolManagerInfo
    {
        public string tag;
        public PoolManager poolManagerScript;
    }
    public Dictionary<string, PoolManager> pmDictionary;
    [System.Serializable] public class ObjectSpawnInfo : IComparable<ObjectSpawnInfo>
    {
        public string tag;//referencia pra achar a pool
        public int spawnTime;
        public ObjectSpawnInfo(string tagRef, int spawnTimeRef)
        {
            tag = tagRef;
            spawnTime = spawnTimeRef;
        }
        public Int32 CompareTo(ObjectSpawnInfo other)
        {
            if(this.spawnTime > other.spawnTime) return 1;
            else if(this.spawnTime < other.spawnTime) return -1;
            else return 0;
        }
    }
    private int index;
    private AudioSource audioSource;
    public int waitTimeSec;
    void Start()
    {
        audioSource = Audio.Instance.audioSource;
        objectsToSpawn = new List<ObjectSpawnInfo>();
        pmDictionary = new Dictionary<string, PoolManager>();
        foreach (PoolManagerInfo poolManager in poolManagerList)
        {
            pmDictionary.Add(poolManager.tag, poolManager.poolManagerScript);
            foreach (InstanceInfo instanceInfo in poolManager.poolManagerScript.poolManagerSO.objectsToSpawn)
            {
                ObjectSpawnInfo objectSpawnInfo = new ObjectSpawnInfo(poolManager.tag, instanceInfo.hitTime - (waitTimeSec * audioSource.clip.frequency));
                objectsToSpawn.Add(objectSpawnInfo);
            }
        }
        objectsToSpawn.Sort();
        //Sortear objectsToSpawn por hitTime
    }
    void Update()
    {
        if(objectsToSpawn.Count>index) if(audioSource.timeSamples >= objectsToSpawn[index].spawnTime)
        {
            //ObjectPooler.Instance.Get(objSpawnTime[index].tag);
            //print("SpawnSomeObject");
            pmDictionary[objectsToSpawn[index].tag].Activate();
            index++;
        }
    }
}
