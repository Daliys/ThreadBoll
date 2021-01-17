using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YarnSpawner : MonoBehaviour
{
    public float dropChance;
    void Awake()
    {
        if (Random.value < dropChance) YarnSpawn();
    }

    void YarnSpawn()
    {
        GameObject gm = Instantiate(transform.GetComponentInParent<YarnHolder>().GetRandomYarn());
        gm.transform.SetParent(transform);
        gm.transform.position = transform.position;
        
    }

  
}
