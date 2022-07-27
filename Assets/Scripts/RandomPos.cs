using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPos : MonoBehaviour
{
    public Vector3 min;
    public Vector3 max;

    public void setPosition()
    {
        transform.localPosition = new Vector3(Random.Range(min.x, max.x), 0, Random.Range(min.z, max.z));
    }
}
