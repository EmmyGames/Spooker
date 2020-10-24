using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class ChildController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    //public float fleeDistance;
    private RaycastHit _hit;
    private FieldOfView _fieldOfView;
    public float fleeDistance;

    private bool _isScared = false;
    private void Start()
    {
        _fieldOfView = GetComponent<FieldOfView>();
    }

    // Update is called once per frame
    private void Update()
    {

        //ChildWander();

        var distance = Vector3.Distance(transform.position, player.transform.position);
        if (_fieldOfView.IsPlayerVisible())
            Flee();
    }

    private void Flee()
    {
        var position = transform.position;
        Vector3 posDiff = position - player.transform.position;
        Vector3 destination = position + posDiff * fleeDistance;
        agent.SetDestination(destination);
    }

    private void ChildWander()
    {
        if (!agent.hasPath && !agent.pathPending)
        {
            if (Random.Range(0, 100) == 1)
            {
                var randomDestination = Random.insideUnitSphere * 6;
                agent.SetDestination(randomDestination);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Scare") && !_isScared)
        {
            Scare(other.transform.position);
        }
    }

    private void Scare(Vector3 pos)
    {
        var distance = Vector3.Distance(transform.position, pos);
        if (distance < 1.5f)
        {
            Debug.Log("large");
        }
        else if (distance < 2.5f)
        {
            Debug.Log("medium");
        }
        else
        {
            Debug.Log("small");
        }

        //_isScared = true;
    }
}
