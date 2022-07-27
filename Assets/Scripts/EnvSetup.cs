using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvSetup : MonoBehaviour
{
    private ObstacleSet obstacleSet;

    private Patrol player;

    private void Awake()
    {
        obstacleSet = GetComponentInChildren<ObstacleSet>();
        player = GetComponentInChildren<Patrol>();
     //   ResetStage();
    }

    public void ResetStage()
    {
        obstacleSet.setObstacles();
        player.SetPoints();
        player.GotoNextPoint();
    }
    private void SpawnEnemies()
    {

    }
}
