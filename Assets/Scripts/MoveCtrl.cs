using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveCtrl : MonoBehaviour
{
    private NavMeshAgent nav;
    public GameObject p1, p2;
    void Start()
    {

    }
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();

    }
    /*
    void Patrol()
    {
        if (!isStopped()) return;
        if ((transform.position - p1.transform.position).sqrMagnitude < 1)
        {

            MoveTo(p2.transform.position);
        }
        else
        {
            MoveTo(p1.transform.position);

        }
    }
    */
    void Update()
    {
        // MoveTo(GameObject.Find("Tank_Hero").transform.position);
    }

    void MoveTo(Vector3 position)
    {
        nav.SetDestination(position);
        nav.Resume();
    }

    public void Stop()
    {
        nav.Stop();
    }

    public void Resume()
    {
        nav.Resume();
    }

    public bool isStopped()
    {

        return nav.remainingDistance <= nav.stoppingDistance;
    }

}
