using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    //public List<SyncObjectSO> objectsToSpawn;
    [SerializeField] private new string tag;
    public ObjectsListSO objectsListSO;
    public PoolManagerSO poolManagerSO;
    [SerializeField] private float spawnRate = 2f;
    private float noteTimer = 0;
    public List<InstanceInfo> objectsToSpawn;
    int index;
    public Transform spawn, view;
    void Start()
    {
        /* for(int i = 0; i < objectsToSpawn.Count; i++)
        {
            objectsToSpawn[i] = new InstanceInfo(objectsToSpawn[i].hitTime, spawn.position, view.position);
            objectsToSpawn[i].tag = tag;
        } */
        GetObjectsInfo();
    }
    void Update()
    {
        //reconhecer qual parte a musica ta 
        //ver se vai spawnar
        noteTimer += Time.deltaTime;
        if(noteTimer >= spawnRate)
        {
            noteTimer -= spawnRate; 
            //Activate();//spawnar
        }
    }
    public void Activate()
    {/* 
        print("Spawned "+name);
        print(name+" Get a object with tag "+tag); */
        SyncObjectInstance syncObjectInstance = ObjectPooler.Instance.Get(tag, transform);       //instanciar
        //print("Activating "+syncObjectInstance+" that returned");
        
        syncObjectInstance.gameObject.SetActive(true);
        if(objectsToSpawn.Count > index) {syncObjectInstance.Activate(objectsToSpawn[index]); index++;}
        //syncObjectInstance.transform.localPosition = Vector3.zero;
        //obj.SetActive(true);
        //mudar o tempo que a proxima nota vai aparecer
        //movimentar
    }
    IEnumerator MoveToTarget()
    {
        //lerp pra o lugar em função do tempo predefinido
        //ObjectPooler.Instance.ReturnToPool(tag, gameObject);//quando chegar, desativar //adicionar de volta pra a lista
        yield return null;
    }
    public void GetObjectsInfo()
    {
        objectsToSpawn = new List<InstanceInfo>();
        for(int i = 0; i < poolManagerSO.objectsToSpawn.Count; i++)
        {
            Vector3 v3 = poolManagerSO.objectsToSpawn[i].spawnPosition;
            v3.z = view.position.z;
            InstanceInfo instInfo = new InstanceInfo(poolManagerSO.objectsToSpawn[i].hitTime, spawn.position, v3);
            instInfo.tag = tag;
            objectsToSpawn.Add(instInfo);
        }
    }
}
