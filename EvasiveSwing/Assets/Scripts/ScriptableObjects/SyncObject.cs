using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SyncObject", menuName = "Sync/Object")]
public class SyncObject : ScriptableObject
{
    public new string name;
    
    [Header("NotesSync")]
    public int instRhythmicFigure;         //DIVISÃO DO BEAT PARA SPAWNAR A NOTA
    public int instBeatDuration;            //PARTE DO BEAT DIVIDIDO A SER TOCADO
    
    //tempo da musica que vc aparece(uma fração antes do tempo que chega na bola)
    //tempo que vc chega na bola

   /*  [SerializeField] private List<float> samplesNotesWaitTimes;     //TEMPOS QUE CADA PROXIMA NOTA TEM QUE ESPERAR EM TIMESAMPLES
    [SerializeField] private int totalTimeSample;
    [SerializeField] private int sampleWaitTimeIndex;               //QUAL TEMPO ESTA SENDO USADO
    [SerializeField] private float nextSpawnTimeSample;             //QUANDO A PROXIMA NOTA SERA SPAWNADA
    [SerializeField] private float noteOffsetSec;                      //QUANTO TEMPO A NOTA VAI APARECER ANTES DO MOMENTO DO HIT (EM SEGUNDOS) */
}
