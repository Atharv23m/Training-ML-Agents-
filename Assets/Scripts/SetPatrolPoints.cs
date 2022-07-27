using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPatrolPoints : MonoBehaviour
{
    private void Start()
    {
        SetPatrol();
    }
    public void SetPatrol()
    {
        foreach (Transform child in transform.GetComponentInChildren<Transform>())
        {
            child.localPosition = new Vector3(Random.Range(-20 , 20) , 0 , Random.Range(-10 , 30));
        }
    }
}
