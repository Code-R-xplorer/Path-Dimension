using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private PlayerControls _playerControls;
    private Vector2 moveDirection;
    private Rigidbody _rigidbody;
    [SerializeField] private float movementSpeed;


    // Start is called before the first frame update

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _playerControls.Controls.Move.performed += context => moveDirection = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 tempVect = new Vector3(moveDirection.x, 0, moveDirection.y);
        tempVect = tempVect.normalized * (movementSpeed * Time.deltaTime);
        _rigidbody.MovePosition(transform.position + tempVect);
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
