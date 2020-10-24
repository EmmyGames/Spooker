using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + _offset, 0.15f);
        
    }
}
