using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YarnHolder : MonoBehaviour
{
    [SerializeField]
    public GameObject[] yarns;

    public GameObject GetRandomYarn()
    {
        return yarns[Random.Range(0, yarns.Length)];
    }
}
