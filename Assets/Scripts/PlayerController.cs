using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController cc;
    
    private const float Gravity = -9.81f;
    
    private float _moveX;
    private float _moveZ;
    private Vector3 _direction = Vector3.zero;
    private Vector3 _moveDir;
    
    public float crouchSpeed;
    public float walkSpeed;
    public float moveSpeed;
    private float _targetAngle;
    private float _angle;
    
    public float turnSmoothTime = 0.15f;
    private float _turnSmoothVelocity;
    
    public float groundDistance;
    public Transform groundCheck;
    public LayerMask groundMask;
    public bool isGrounded;
    
    private Vector3 _velocity = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && _velocity.y < 0f)
        {
            //Reset the velocity that it had accumulated while on the ground
            _velocity.y = -2f;
        }
        
        
        moveSpeed = Input.GetButton("Crouch") ? crouchSpeed : walkSpeed;
        
        _moveX = Input.GetAxis("Horizontal");
        _moveZ = Input.GetAxis("Vertical");
        _direction = new Vector3(_moveX, 0f, _moveZ);
        if (_direction.magnitude > 1f)
            _direction = _direction.normalized;
        _targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
        
        if (_direction.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.Euler(0f, _angle, 0f);
            _moveDir = Quaternion.Euler(0f, _targetAngle, 0f) * Vector3.forward;
            cc.Move(Time.deltaTime * moveSpeed * _moveDir);
        }
        _velocity.y += Gravity * Time.deltaTime;
        cc.Move(_velocity * Time.deltaTime);
        
    }
}
