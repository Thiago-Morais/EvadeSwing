using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private new string tag = "Line";
    void Update()
    {
        //reconhecer qual parte a musica ta 
        //ver se vai spawnar 
        //spawnar
    }
    void Activate()
    {
        ObjectPooler.Instance.Get(tag, transform);       //instanciar
        //mudar o tempo que a proxima nota vai aparecer
        //movimentar
    }
    IEnumerator MoveToTarget()
    {
        //lerp pra o lugar em função do tempo predefinido
        /* ObjectPooler.Instance.ReturnToPool(tag, gameObject); //quando chegar, desativar //adicionar de volta pra a lista*/
        yield return null;
    }
    /* public void StartNotes()
    {
        StartCoroutine(NoteChart());
    }
    IEnumerator NoteChart()
    {
        float noteOffsetTimeSample = noteOffsetSec * audioSource.clip.frequency;            //CALCULA QUANTO TEMPO A NOTA VAI APARECER ANTES DO MOMENTO DO HIT

        nextSpawnTimeSample = samplesNotesWaitTimes[sampleWaitTimeIndex];
        sampleWaitTimeIndex++;
        
        bool keySwitch = true;
        while (keySwitch)
        {                                                          //VERIFICA SE CONTINUA SPAWNANDO NOTA
            if(AudioLooped()){keySwitch = false; StartNotesAgain();}                    //QUANDO FAZ O LOOP, REINICIA AS NOTAS
            else if(audioSource.timeSamples >= nextSpawnTimeSample - noteOffsetTimeSample)                     //SPAWNA UMA NOTA QUANDO CHEGAR NO TEMPO DELA 
            {
                SpawnInstance();                                                        //SPAWNA A NOTA
                if(sampleWaitTimeIndex < samplesNotesWaitTimes.Count)                   //VERIFICA SE JA PASSARAM TODAS AS NOTAS SALVAS
                {
                    nextSpawnTimeSample += samplesNotesWaitTimes[sampleWaitTimeIndex];  //AUMENTA O TEMPO QUE OUTRA NOTA VAI APARECER 
                    sampleWaitTimeIndex++;                                              //VAI PRA O TEMPO DE ESPERA DA PROXIMA NOTA
                }
                else break;
            }
            yield return null;
        }
    } */
}
