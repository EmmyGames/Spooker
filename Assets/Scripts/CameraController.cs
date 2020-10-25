using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Vector3 _offset;

    public AudioClip[] gruntSounds;
    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - player.position;
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + _offset, 0.15f);
        if (Input.GetButtonDown("Scare") && Time.timeScale > 0f)
        {
            Scare();
        }
    }
    
    private void Scare()
    {
        AudioClip clip = gruntSounds[Random.Range(0, gruntSounds.Length)];
        _audioSource.PlayOneShot(clip);
    }
}
