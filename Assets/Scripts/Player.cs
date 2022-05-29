using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    private PlayerControls _playerControls;
    private Vector2 moveDirection;
    private Vector2 lookDirection;
    private Rigidbody _rigidbody;
    [SerializeField] private float movementSpeed;
    private Vector3 movement;
    private Vector3 look;
    [SerializeField] private MouseLook _mouseLook;
    private Vector3 _playerSpawnPos;

    

    // Start is called before the first frame update

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _rigidbody = GetComponent<Rigidbody>();
        _playerSpawnPos = GameObject.Find("PlayerSpawn").transform.position;
    }

    void Start()
    {
        _playerControls.Controls.Move.performed += context => moveDirection = context.ReadValue<Vector2>();
        _playerControls.Controls.Look.performed += context => lookDirection = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(moveDirection.x, 0, moveDirection.y);
        _mouseLook.ReceiveInput(lookDirection);
        if (transform.position.y < -5)
        {
            transform.position = _playerSpawnPos;
        }
    }

    private void FixedUpdate()
    {
        // Vector3 tempVect = new Vector3(moveDirection.x, 0, moveDirection.y);
        // tempVect = tempVect.normalized * (movementSpeed * Time.deltaTime);
        // _rigidbody.MovePosition(transform.position + tempVect);
        // Vector3 offset = new Vector3(movement.x * transform.position.x, movement.y * transform.position.y, movement.z * transform.position.z);
        // _rigidbody.MovePosition(transform.position + offset * (movementSpeed * Time.deltaTime));
        
        
        float cameraRot = Camera.main.transform.rotation.eulerAngles.y;
        _rigidbody.position += Quaternion.Euler(0, cameraRot, 0) * movement * (movementSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }
}
