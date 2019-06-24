using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class XMLManager : MonoBehaviour
{
    public static XMLManager ins;
    private void Awake(){ins = this;}
    public ItemDatabase itemDB = new ItemDatabase(1);     //Lista de itens
    private void OnValidate()
    {
        while(itemDB.list.Count < itemDB.list.Capacity) itemDB.list.Add(new InstanceInfo());
    }
    SyncManager syncManager;
/* 
    [EasyButtons.Button]//Save function
    public void SaveItems()
    {
        //Abrir um arquivo XML
        XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
        FileStream stream = new FileStream(Application.dataPath+"/StreamingFiles/XML/item_data.xml", FileMode.Create);
        serializer.Serialize(stream, itemDB);
        stream.Close();
    } */
    /* 
    [EasyButtons.Button]//Load function
    public void LoadItems()
    {
        //Abrir um arquivo XML
        XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
        FileStream stream = new FileStream(Application.dataPath+"/StreamingFiles/XML/item_data.xml", FileMode.Open);
        itemDB = serializer.Deserialize(stream) as ItemDatabase;
        stream.Close();
    } */
    private void Start()
    {
        syncManager = SyncManager.Instance;
    }
    [EasyButtons.Button]//Save function
    public void SaveItems()
    {
        //Abrir um arquivo XML
        XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
        FileStream stream = new FileStream(Application.dataPath+"/StreamingFiles/XML/SyncObjects.xml", FileMode.Create);
        serializer.Serialize(stream, syncManager.objectsToSpawn);
        stream.Close();
    }
    [EasyButtons.Button]//Load function
    public void LoadItems()
    {
        //Abrir um arquivo XML
        XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
        FileStream stream = new FileStream(Application.dataPath+"/StreamingFiles/XML/SyncObjects.xml", FileMode.Open);
        syncManager.objectsToSpawn = serializer.Deserialize(stream) as List<SyncManager.ObjectSpawnInfo>;
        stream.Close();
        foreach (SyncManager.PoolManagerInfo poolManagerInfo in syncManager.poolManagerList)
        {
            poolManagerInfo.poolManagerScript.GetObjectsInfo();
        }
    }
}/* 
[System.Serializable]
public class ItemEntry
{
    public string tag;
    public InstanceInfo instanceInfo = new InstanceInfo(); 
} */
[System.Serializable]
public class ItemDatabase
{
    public List<InstanceInfo> list;
    public ItemDatabase(int size)
    {
        list = new List<InstanceInfo>(size);
    }public ItemDatabase()
    {
        list = new List<InstanceInfo>();
    }

}