using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    #region Singleton
    public static ObjectPooler Instance{get; private set;}
    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    #endregion
    public List<Pool> pools;
    [System.Serializable] public class Pool
    {
        public string tag;
        public Transform prefabParent;
        public GameObject prefab;
        public int size;
    }
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();   //Cria o Dicionário
        foreach (Pool pool in pools)                                    
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            /* for(int i = 0; i < pool.size; i++)                       //Enche cada Piscina
            {
                GameObject obj = Instantiate(pool.prefab, pool.prefabParent);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            } */
            poolDictionary.Add(pool.tag, objectPool);                   //Adiciona a piscina no dicionario
        }
    }
    public GameObject Get(string tag)
    {
        if(poolDictionary[tag].Count == 0) AddObject(tag, 1);
        return poolDictionary[tag].Dequeue();
    }
    public GameObject Get(string tag, Transform parent)
    {
        if(poolDictionary[tag].Count == 0) AddObject(tag, 1);
        GameObject obj = poolDictionary[tag].Dequeue();
        obj.transform.parent = parent;
        return obj;
    }
    public void ReturnToPool(string tag, GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        poolDictionary[tag].Enqueue(objectToReturn);
    }
    public void AddObject(string tag, int count)
    {
        Pool poolToAdd = FindPoolByTag(tag, pools);
        for(int i = 0; i < count; i++)                       //Enche cada Piscina
        {
            var obj = Instantiate(poolToAdd.prefab, poolToAdd.prefabParent);
            obj.SetActive(false);
            poolDictionary[tag].Enqueue(obj);
        }
    }
    public Pool FindPoolByTag (string tag, List<Pool> list)
    {
        for(int i = 0; i < list.Count; i++) if(list[i].tag == tag) return list[i];
        return null;
    }

    public GameObject SpawnFromPool(string tag, Vector3 position)
    {
        if(!poolDictionary.ContainsKey(tag)){Debug.LogWarning("Pool with tag "+tag+" doesn't exist."); return null;}
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;

        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
