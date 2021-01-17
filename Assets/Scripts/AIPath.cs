using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPath : MonoBehaviour
{

    public Points[] pathPoints;

    [System.Serializable]
    public struct Points
    {
        public Transform[] innersPoints;
    }

    public Vector3 GetRandomPosition(int stage)
    {
        if (stage < pathPoints.Length) return pathPoints[stage].innersPoints[Random.Range(0, pathPoints[stage].innersPoints.Length)].position;
        else return Vector3.zero;
    }

    public int GetLength()
    {
        return pathPoints.Length;
    }

}
