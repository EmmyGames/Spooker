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

    public float meshResolution = 1f;
    
    
    
    
    
    
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

    }

    private void DrawFieldOfView()
    {
        int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
        float stepAngleSize = viewAngle / stepCount;
        List<Vector3> viewPoints = new List<Vector3>();
        for (int i = 0; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.y - viewAngle / 2 + stepAngleSize * i;
            //Debug.DrawLine(transform.position, transform.position + DirectionFromAngle(angle, true) * viewRadius, Color.red);
            ViewCastInfo newViewCast = ViewCast(angle);
            viewPoints.Add(newViewCast.point);
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];
        
        
    }

    private ViewCastInfo ViewCast(float globalAngle)
    {
        Vector3 dir = DirectionFromAngle(globalAngle, true);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, dir, out hit, viewRadius))
        {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else
        {
            return new ViewCastInfo(false, transform.position + dir * viewRadius, viewRadius, globalAngle);
        }
    }

    public struct ViewCastInfo
    {
        public bool hit;
        public Vector3 point;
        public float distance;
        public float angle;

        public ViewCastInfo(bool _hit, Vector3 _point, float _distance, float _angle)
        {
            hit = _hit;
            point = _point;
            distance = _distance;
            angle = _angle;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        DirectionFromAngle(viewAngle, false);
        DrawFieldOfView();
    }
}
