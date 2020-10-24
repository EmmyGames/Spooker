using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyScore : MonoBehaviour
{
    public int candyScore;
    private Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameState.UpdateScore(candyScore);
            Destroy(gameObject);
        }
    }
}
