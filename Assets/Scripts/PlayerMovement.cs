using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    private const float GRAVITY = -25f;

    [SerializeField] private float _moveSpeed = 100f;
    [SerializeField] private float _jumpSpeed = 50f;
    [SerializeField] private float _rotationSpeed = 100f;
    [SerializeField] private GameObject _hand;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _whatIsGround;

    private CharacterController _controller;

    private float _yVel;
    private float _yRotLimit = 85f;
    private float _currentYRot = 0;
    
    private bool _isGrounded = false;
    private float _groundCheckRadius = 0.2f;
    void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckRadius, _whatIsGround);
        HandleMovement();
        HandleRotation();
    } 

    void HandleMovement()
    {
        Vector3 velocity = new Vector3 { };
        if (!_isGrounded)
        {
            _yVel += GRAVITY * Time.deltaTime;
        }
        else
        {
            _yVel = 0;
        }

        
        float axisMovement = 0;

        if ((axisMovement = Input.GetAxis("Vertical")) != 0)
        {
            Vector3 fwd = transform.forward;
            velocity += fwd * axisMovement * _moveSpeed;
        }

        if ((axisMovement = Input.GetAxis("Horizontal")) != 0)
        {
            Vector3 right = transform.right;
            velocity += right * axisMovement * _moveSpeed;
        }

        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _yVel = _jumpSpeed;
        }
        velocity.y = _yVel;

        _controller.Move(velocity * Time.deltaTime);
    }

    void HandleRotation()
    {
        float mouseMovement = 0;

        if ((mouseMovement = Input.GetAxis("Mouse X")) != 0)
        {
            transform.Rotate(transform.up, mouseMovement * _rotationSpeed * Time.deltaTime);
        }

        if ((mouseMovement = Input.GetAxis("Mouse Y")) != 0 && _hand != null)
        {

            _currentYRot -= mouseMovement * _rotationSpeed * Time.deltaTime;
            _currentYRot = Mathf.Clamp(_currentYRot, -_yRotLimit, _yRotLimit);
            _hand.transform.localEulerAngles = new Vector3(_currentYRot, 0, 0);
        }
    }
}
