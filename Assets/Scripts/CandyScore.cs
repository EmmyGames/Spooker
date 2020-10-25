using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CandyScore : MonoBehaviour
{
    public int candyScore;
    private Collider _collider;
    public AudioClip[] biteSounds;
    private AudioSource _audioSource;
    
    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            AudioSource.PlayClipAtPoint(biteSounds[Random.Range(0, biteSounds.Length)], Camera.main.transform.position);
            
            AudioClip clip = biteSounds[Random.Range(0, biteSounds.Length)];
            GameState.UpdateScore(candyScore);
            Destroy(gameObject);
        }
    }
}
