using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncObjectInstance : MonoBehaviour
{/* 
    public Transform m_spawnTransform, m_targetTransform;
    public int spawnTime, m_hitTime; */ 
    public string m_tag;
    public float spawnTime;
    [SerializeField] private AudioSource audioSource;
    public InstanceInfo m_instanceInfo = new InstanceInfo();
    
    private void Awake()
    {
        audioSource = Audio.Instance.audioSource;
    }/* 
    public void Activate(Transform spawnTransform, Transform targetTransform, int hitTime)
    {
        spawnTime = audioSource.timeSamples;
        SetValues(spawnTransform, targetTransform, hitTime);
        StartCoroutine(LerpToTarget());
    } */
    
    public void Activate(InstanceInfo instanceInfo)
    {
        gameObject.SetActive(true);
        spawnTime = audioSource.timeSamples;
        SetValues(instanceInfo);
        StartCoroutine(LerpToTarget());
    }
    public void SetValues(InstanceInfo instanceInfo)
    {
        //m_spawnTransform = spawnTransform;
        //m_targetTransform = targetTransform;
        //m_hitTime = hitTime;
        /* 
        m_instanceInfo.hitTime = instanceInfo.hitTime;
        m_instanceInfo.spawnTransform =  instanceInfo.spawnTransform;
        m_instanceInfo.targetTransform = instanceInfo.targetTransform; */
        m_instanceInfo = instanceInfo;
    }
    /* public void SetValues(Transform spawnTransform, Transform targetTransform, int hitTime)
    {
        //m_spawnTransform = spawnTransform;
        //m_targetTransform = targetTransform;
        //m_hitTime = hitTime;
        
        instanceInfo.spawnTransform = spawnTransform;
        instanceInfo.targetTransform = targetTransform;
        instanceInfo.hitTime = hitTime;
    } */
    /* private void OnEnable()
    {
        spawnTime = audioSource.timeSamples;
        StartCoroutine(LerpToTarget());
    } */
    IEnumerator LerpToTarget()
    {
        bool keySwitch = true;
        float t = 0;
        while (keySwitch)
        {
            t = Mathf.InverseLerp(spawnTime, m_instanceInfo.hitTime, audioSource.timeSamples);       //Seta interpolação em função da musica
            /* print(name);
            print("spawnTime ="+spawnTime);
            print("m_instanceInfo.hitTime ="+m_instanceInfo.hitTime);
            print("audioSource.timeSamples ="+audioSource.timeSamples); */
            transform.position =  Vector3.Lerp(m_instanceInfo.spawnPosition, m_instanceInfo.targetPosition, t);       //Interpola a posição
            transform.rotation = Quaternion.Lerp(m_instanceInfo.spawnRotation, m_instanceInfo.targetRotation, t);     //Interpola a posição
            transform.localScale = Vector3.Lerp(m_instanceInfo.spawnScale, m_instanceInfo.targetScale, t);  //Interpola a escala
            //print(name+" "+t);
            if(t >= 1) 
            {
                keySwitch = false;
                ObjectPooler.Instance.ReturnToPool(m_tag, this);
            }
            yield return null;
        }
    }
}

