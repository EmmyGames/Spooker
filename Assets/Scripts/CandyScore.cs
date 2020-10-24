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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log(candyScore);
            _collider.enabled = false;
            Destroy(gameObject, 2f);
        }
    }
}
