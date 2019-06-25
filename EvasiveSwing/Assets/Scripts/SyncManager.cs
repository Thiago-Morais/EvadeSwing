using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class SyncManager : MonoBehaviour
{
    [Header("Sync Objects List")]
    public ObjectsListSO objectsListSO;
    public List<ObjectSpawnTime> objectsSpawnTime;
    public List<PoolManagerInfo> poolManagerList;
    public Dictionary<string, PoolManager> pmDictionary;
    [Header("Spawn")]
    [SerializeField] private int waitTimeSec;
    private int index;
    private AudioSource audioSource;
    public static SyncManager Instance;
    #region Singleton
    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    #endregion
    [System.Serializable] public class PoolManagerInfo
    {
        public string tag;
        public PoolManager poolManagerScript;
    }
    [System.Serializable] public class ObjectSpawnTime : IComparable<ObjectSpawnTime>
    {
        public string tag;//referencia pra achar a pool
        public int spawnTime;
        public ObjectSpawnTime(string tagRef, int spawnTimeRef)
        {
            tag = tagRef;
            spawnTime = spawnTimeRef;
        }
        public Int32 CompareTo(ObjectSpawnTime other)
        {
            if(this.spawnTime > other.spawnTime) return 1;
            else if(this.spawnTime < other.spawnTime) return -1;
            else return 0;
        }
    }
    void Start()
    {
        audioSource = Audio.Instance.audioSource;

        objectsSpawnTime = objectsListSO.objectsSpawnTime;

        //objectsToSpawn = new List<ObjectSpawnInfo>();
        pmDictionary = new Dictionary<string, PoolManager>();
        foreach (PoolManagerInfo poolManager in poolManagerList)
        {
            pmDictionary.Add(poolManager.tag, poolManager.poolManagerScript);
            foreach (InstanceInfo instanceInfo in poolManager.poolManagerScript.poolManagerSO.objectsToSpawn)
            {
                ObjectSpawnTime objectSpawnInfo = new ObjectSpawnTime(poolManager.tag, instanceInfo.hitTime - (waitTimeSec * audioSource.clip.frequency));
                //objectsToSpawn.Add(objectSpawnInfo);
            }
        }
        //objectsToSpawn.Sort();
    }
    void Update()
    {
        if(objectsSpawnTime.Count > index) if(audioSource.timeSamples >= objectsSpawnTime[index].spawnTime)
        {
            //ObjectPooler.Instance.Get(objSpawnTime[index].tag);
            //print("SpawnSomeObject");
            pmDictionary[objectsSpawnTime[index].tag].Activate();
            index++;
        }
    }
}
