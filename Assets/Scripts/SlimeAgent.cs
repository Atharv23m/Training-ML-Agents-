using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using System;
using Unity.MLAgents.Actuators;

public class SlimeAgent : Agent 
{
    public bool trainingMode = true;

    public float moveSpeed = 5f;

    public float dashSpeed = 10f;

    public float Jumpforce = 5f;

    private GameObject player;

    private Rigidbody root;

    private Move controller;

    private EnvSetup env;

    private float x = 0, y = 0;

    public override void Initialize()
    {
        foreach (Transform child in transform.GetComponentInChildren<Transform>())
        {
            if (child.tag == "Slime")
            {
                root = child.GetComponent<Rigidbody>();
                controller = child.GetComponent<Move>();
                break;
            }
        }
            env = GetComponentInParent<EnvSetup>();
        foreach (Transform child in transform.parent.GetComponentInChildren<Transform>())
        {
            if (child.tag == "Player")
                player = child.gameObject;
        }

        MaxStep = 4000;
            // if not in training mode, no max step, play forever
            if (!trainingMode)
            MaxStep = 0;
    }

    public override void OnEpisodeBegin()
    {
        env.ResetStage();
        root.transform.localPosition = new Vector3( 0 , -5 ,0);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
         x = Mathf.MoveTowards(x, actions.ContinuousActions[0], 2f * Time.fixedDeltaTime);
         y = Mathf.MoveTowards(y, actions.ContinuousActions[1], 2f * Time.fixedDeltaTime);

        controller.Movement(new Vector2(x, y));
        if (actions.DiscreteActions[0] == 1)
        {
            controller.Jump();
        }
        if (controller.OnPlatform())
            AddReward(0.02f);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(player.transform.position);
        float dist = Vector3.Magnitude(root.position - player.transform.position);
        sensor.AddObservation(dist);
        sensor.AddObservation((root.position - player.transform.position).normalized);
        if (dist > 3 && dist < 7)
            AddReward(0.1f);
        if (dist > 15)
            AddReward(-0.05f);
    }

    private void FixedUpdate()
    {
        if(root.transform.position.y < -20)
        {
            root.transform.localPosition = new Vector3(0, 0, 0);
            AddReward(-1f);
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var inp = actionsOut.ContinuousActions;

        inp[0] = Input.GetAxis("Horizontal");
        inp[1] = Input.GetAxis("Vertical");

    }
    public override void WriteDiscreteActionMask(IDiscreteActionMask actionMask)
    {
        
    }
}
