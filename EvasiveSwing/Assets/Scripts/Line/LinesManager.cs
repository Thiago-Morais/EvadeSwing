using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesManager : MonoBehaviour
{
    [SerializeField] private new string tag = "Line";
    [SerializeField] private float spawnRate = 2f;
    private float noteTimer = 0;
    void Update()
    {
        //reconhecer qual parte a musica ta 
        //ver se vai spawnar
        noteTimer += Time.deltaTime;
        if(noteTimer >= spawnRate)
        {
            noteTimer -= spawnRate; 
            Activate();//spawnar
        }
    }
    void Activate()
    {
        var obj = ObjectPooler.Instance.Get(tag, transform);       //instanciar
        obj.transform.localPosition = Vector3.zero;
        obj.SetActive(true);
        //mudar o tempo que a proxima nota vai aparecer
        //movimentar
    }
    IEnumerator MoveToTarget()
    {
        //lerp pra o lugar em função do tempo predefinido
        ObjectPooler.Instance.ReturnToPool(tag, gameObject);//quando chegar, desativar //adicionar de volta pra a lista
        yield return null;
    }
}
