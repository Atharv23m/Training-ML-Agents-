using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSet : MonoBehaviour
{
    private void Start()
    {
    //    setObstacles();
    }
    
    public void setObstacles()
    {
        foreach(Transform child in transform.GetComponentInChildren<Transform>())
        {
            child.GetComponent<RandomPos>().setPosition();
        }
    }
}
