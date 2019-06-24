using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InstanceInfo
{
    public string tag;
    public int hitTime;
    //public Transform spawnTransform, targetTransform;
    public Vector3 spawnPosition;
    public Vector3 targetPosition;
    public Quaternion spawnRotation = Quaternion.Euler(Vector3.zero);
    public Quaternion targetRotation = Quaternion.Euler(Vector3.zero);
    public Vector3 spawnScale = Vector3.one, targetScale = Vector3.one;
            //Constructors
    public InstanceInfo ()
    {
    }
    public InstanceInfo (int m_hitTime)
    {
        hitTime = m_hitTime;
    }
    public InstanceInfo (int m_hitTime, 
        Vector3 m_spawnPosition, Vector3 m_targetPosition)
    {
        hitTime = m_hitTime;
        spawnPosition = m_spawnPosition;
        targetPosition = m_targetPosition;
    }
    public InstanceInfo (int m_hitTime, 
        Vector3 m_spawnPosition, Vector3 m_targetPosition, 
        Vector3 m_spawnScale, Vector3 m_targetScale)
    {
        hitTime = m_hitTime;
        spawnPosition = m_spawnPosition;
        spawnScale = m_spawnScale;
        targetPosition = m_targetPosition;
        targetScale = m_targetScale;
    }
    public InstanceInfo (int m_hitTime, 
        Vector3 m_spawnPosition, Vector3 m_targetPosition, 
        Quaternion m_spawnRotation, Quaternion m_targetRotation, 
        Vector3 m_spawnScale, Vector3 m_targetScale)
    {
        hitTime = m_hitTime;
        spawnPosition = m_spawnPosition;
        spawnRotation = m_spawnRotation;
        spawnScale = m_spawnScale;
        targetPosition = m_targetPosition;
        targetRotation = m_targetRotation;
        targetScale = m_targetScale;
    }
}
