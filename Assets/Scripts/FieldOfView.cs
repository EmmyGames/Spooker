using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius = 4f;
    [Range(0,360)]
    public float viewAngle = 115f;
    private GameObject _player;
    
    private RaycastHit _hit;
    
    public Vector3 DirectionFromAngle(float angle, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
            angle += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
    }

    public bool IsPlayerVisible()
    {
        Vector3 directionToPlayer = (_player.transform.position - transform.position).normalized;
        //if player is within the view angle
        if (Vector3.Angle(transform.forward, directionToPlayer) < viewAngle / 2)
        {
            Debug.DrawRay(transform.position, directionToPlayer * 30, Color.green);
            if (Physics.Raycast(transform.position + new Vector3(0,1,0), directionToPlayer, out _hit, viewRadius))
            {
                if (_hit.collider.gameObject.name == "Player")
                {
                    return true;
                }
            }
        }
        return false;
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        /*
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        
        Vector3[] vertices = new Vector3[3];
        Vector2[] uv = new Vector2[3];
        int[] triangles = new int[3];

        vertices[0] = Vector2.zero;
        vertices[1] = new Vector3(50, 50);
        vertices[2] = new Vector3(0, -50);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        */

    }

    // Update is called once per frame
    void Update()
    {
        DirectionFromAngle(viewAngle, false);
    }
}
