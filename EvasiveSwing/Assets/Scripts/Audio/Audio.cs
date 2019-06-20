using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource m_audioSource;
    public static AudioSource audioSource;
    public static Audio Instance {get; private set;}
    #region Singleton
    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
        audioSource = m_audioSource;
    }
    #endregion
    public int bpm = 120;
    public float bps;       //BEATS POR SEGUNDO
    public static float tspb;       //TIMESAMPLES POR BEAT
    void Start()
    {
        audioSource.Play();
        bps = bpm / 60.0f;                          //BEATS POR SEGUNDO
        tspb = audioSource.clip.frequency / bps;    //TIMESAMPLES POR BEATS
    }
}
