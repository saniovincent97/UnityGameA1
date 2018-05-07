using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    NavMeshAgent agent;
    public Transform[] points;
    private int destPoint = 0;
    Transform player;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();

    }


    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        agent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }



    void Update ()
    {
        if (!agent.pathPending && agent.remainingDistance < 1f)
            GotoNextPoint();


        if (Mathf.Abs(Vector3.Distance(this.transform.position, player.transform.position)) <= 6)
        {
            chase();
        }


    }


    void chase()
    {
        agent.destination = player.transform.position;
        agent.Resume();
    }
}
