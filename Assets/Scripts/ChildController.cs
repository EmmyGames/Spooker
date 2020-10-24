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
    public Animator anim;
    
    //public float fleeDistance;
    private RaycastHit _hit;
    private FieldOfView _fieldOfView;
    public float fleeDistance = 10f;

    private const float TurnSmoothTime = 1f;
    private float _turnSmoothVelocity;
    private float _angle;
    private float _theta;

    public float scareDistance = 3.5f;

    private float _distanceFromPlayer;
    
    private bool _isScared = false;

    public GameObject[] candies;
    
    
    private void Start()
    {
        _fieldOfView = GetComponent<FieldOfView>();
    }

    // Update is called once per frame
    private void Update()
    {
        _distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (_fieldOfView.IsPlayerVisible())
            Flee();
        if (Input.GetButtonDown("Scare") && !_isScared)
        {
            Scare();
        }
    }

    private void FixedUpdate()
    {
        ChildWander();
    }

    private void Flee()
    {
        anim.SetBool("isRunning", true);
        _isScared = true;
        agent.speed = 7f;
        var position = transform.position;
        Vector3 posDiff = position - player.transform.position;
        Vector3 destination = (position + posDiff * fleeDistance);
        destination = new Vector3(destination.x, 0, destination.z);
        agent.SetDestination(destination);
    }

    private void ChildWander()
    {
        if (!agent.hasPath && !agent.pathPending)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
            agent.speed = 3.5f;
            _isScared = false;
            int rand = Random.Range(1, 301);
            if (rand < 3)
            {
                anim.SetBool("isWalking", true);
                var randomDestination = Random.insideUnitSphere * 6;
                agent.SetDestination(randomDestination);
            }
            else if (rand > 296)
            {
                _theta = Random.Range(0, 360);
            }
            _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _theta, ref _turnSmoothVelocity, TurnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, _angle, 0f);
        }
    }

    private void Scare()
    {
        if (_distanceFromPlayer <= scareDistance)
        {
            if (Physics.Raycast(transform.position + new Vector3(0,1,0), player.transform.position - transform.position, out _hit, scareDistance))
            {
                if (_hit.collider.gameObject.name == "Player")
                {
                    Vector3 candyPosition = transform.position + transform.forward;
                    GameObject candy;
                    if (_distanceFromPlayer < 1.5f)
                    {
                        candy = candies[2];
                    }
                    else if (_distanceFromPlayer < 2.5f)
                    {
                        candy = candies[1];
                    }
                    else
                    {
                        candy = candies[0];
                    }

                    Instantiate(candy, transform.position + transform.forward + candy.transform.position, candy.transform.rotation);
                    Flee();
                }
            }
        }
    }
}
