using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavBake : MonoBehaviour
{
    private NavMeshSurface srf;
    // Start is called before the first frame update
    void Start()
    {
        srf = GetComponent<NavMeshSurface>();
        BuildSurface();
    }
    
    private void BuildSurface()
    {
        srf.BuildNavMesh();
    }
}
