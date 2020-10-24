using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChildController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    //public float fleeDistance;
    private RaycastHit _hit;
    private FieldOfView _fieldOfView;
    public float fleeDistance;
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
            if (Random.Range(0, 500) == 1)
            {
                var randomDestination = Random.insideUnitSphere * 12;
                agent.SetDestination(randomDestination);
            }
        }
    }
}
