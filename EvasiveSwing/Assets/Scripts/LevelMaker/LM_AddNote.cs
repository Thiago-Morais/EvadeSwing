using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LM_AddNote : MonoBehaviour
{
    public int distanceToCamera;
    public ObjectsListSO objectsListSO;
    private AudioSource audioSource;
    //public Dictionary<string, PoolManager> pmDictionary;
    public Dictionary<string, PoolManagerSO> pmDictionary;
    public List<PoolManagerInfo> poolManagerList;
    [System.Serializable] public class PoolManagerInfo
    {
        public string tag;
        //public PoolManager poolManagerRef;
        public PoolManagerSO poolManagerRef;
    }
    public bool overrideObjects;
    private void Start()
    {
        //pmDictionary = new Dictionary<string, PoolManager>();
        pmDictionary = new Dictionary<string, PoolManagerSO>();
        foreach (PoolManagerInfo poolManager in poolManagerList)
        {
            if(overrideObjects) poolManager.poolManagerRef.objectsToSpawn.Clear();
            pmDictionary.Add(poolManager.tag, poolManager.poolManagerRef);
        }
        audioSource = Audio.Instance.audioSource;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 v3 = new Vector3(
                Mathf.Clamp(Input.mousePosition.x, 0, Camera.main.pixelWidth), 
                Mathf.Clamp(Input.mousePosition.y, 0, Camera.main.pixelHeight), 
                Camera.main.transform.position.z + distanceToCamera);
            v3 = Camera.main.ScreenToWorldPoint(v3);
            print(v3);
            
            InstanceInfo instInfo = new InstanceInfo();
            instInfo.hitTime = audioSource.timeSamples;
            instInfo.spawnPosition = v3;
            instInfo.targetPosition = v3;

            if(Input.GetKey(KeyCode.Q))
            {
                instInfo.tag = "Line";
                pmDictionary["Line"].objectsToSpawn.Add(instInfo);
            }
            else if(Input.GetKey(KeyCode.W))
            {
                instInfo.tag = "Note";
                pmDictionary["Note"].objectsToSpawn.Add(instInfo);
            }
            else if(Input.GetKey(KeyCode.E))
            {
                instInfo.tag = "Wall";
                pmDictionary["Wall"].objectsToSpawn.Add(instInfo);
            }
        }
        if(overrideObjects)
        {
            ClearNotes();
            overrideObjects = false;
        }
    }
    public void ClearNotes()
    {
        foreach (PoolManagerInfo poolManager in poolManagerList)
        {
            poolManager.poolManagerRef.objectsToSpawn.Clear();
        }
    }
}
