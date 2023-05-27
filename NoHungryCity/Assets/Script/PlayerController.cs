using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private PlayerInputSystem playerInputSystem;

    [SerializeField] private WheelCollider frontRight;
    [SerializeField] private WheelCollider frontLeft;
    [SerializeField] private WheelCollider BackRight;
    [SerializeField] private WheelCollider BackLeft;

    public float acceleration = 500f;
    public float brakingForce = 300f;
    public float maxTurnAngle = 15f;
    private float currentAcceleration = 0f;
    private float currentBrakeForce = 0f;
    private float currentTurnAngle = 0f;

    [Header("Movement Inputs")]
    private Vector2 carMovementInput;
    private Vector3 carMovement;
    private bool isStopping;
    private bool isMoving;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerInputSystem = new PlayerInputSystem();

        playerInputSystem.Player.Movement.started += OnMovementInput;
        playerInputSystem.Player.Movement.canceled += OnMovementInput;
        playerInputSystem.Player.Movement.performed += OnMovementInput;

        playerInputSystem.Player.Brake.started += OnBrakingInput;
        playerInputSystem.Player.Brake.canceled += OnBrakingInput;
    }

    void FixedUpdate()
    {
        SetMovement();
    }

    void SetMovement() 
    {    
        currentAcceleration = acceleration * carMovement.z;

        if (isStopping)
            currentBrakeForce = brakingForce;
        else
            currentBrakeForce = 0f;

        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        frontRight.brakeTorque = currentBrakeForce;
        frontLeft.brakeTorque = currentBrakeForce;
        BackRight.brakeTorque = currentBrakeForce;
        BackLeft.brakeTorque = currentBrakeForce;

        currentTurnAngle = maxTurnAngle * carMovement.x;
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        if (isMoving)
            Debug.Log("to andando");
    }

    void OnMovementInput(InputAction.CallbackContext context)
    {
        carMovementInput = context.ReadValue<Vector2>();
        carMovement = new Vector3(carMovementInput.x, 0f, carMovementInput.y);

        isMoving = carMovementInput.x != 0 || carMovementInput.y != 0;
    }

    void OnBrakingInput(InputAction.CallbackContext context)
    {
        isStopping = context.ReadValueAsButton();
    }

    private void OnEnable()
    {
        playerInputSystem.Player.Enable();
    }

    private void OnDisable()
    {
        playerInputSystem.Player.Disable();
    }
}
