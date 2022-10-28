using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField] private Rigidbody rb;

    /// <summary> Acceleration when the player moves </summary>
    [SerializeField] private float acceleration = 50f;

    /// <summary> Friction when the player is not controlled </summary>
    [SerializeField] private float friction = 50f;
    
    /// <summary> The speed the player will not exceed </summary>
    [SerializeField] private float standartVelocity = 5f;

    /// <summary> Mouse sensitivity </summary>
    [SerializeField] private float mouseSensitivity = 100f;


    /// <summary> Player's camera </summary>
    private Camera cam;
    
    /// <summary> Camera direction </summary>
    private Vector2 _cameraLookDirection;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        HandleMovementControl();
    }

    void FixedUpdate()
    {
        // HandleMovementControl();
        HandleCameraControl();
    }

    private void HandleMovementControl()
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.z = Input.GetAxis("Vertical");
        moveDirection.Normalize();
        // moveDirection = transform.right * moveDirection.x + transform.forward * moveDirection.z;

        moveDirection = cam.transform.right * moveDirection.x + cam.transform.forward * moveDirection.z;

        // Horizontal velocity
        Vector2 hVelocity = new Vector2(rb.velocity.x, rb.velocity.z);

        if(moveDirection != Vector3.zero)
        {
            hVelocity.x += moveDirection.x * acceleration * Time.deltaTime;
            hVelocity.y += moveDirection.z * acceleration * Time.deltaTime;

            if(hVelocity.magnitude > standartVelocity)
                hVelocity = hVelocity.normalized*standartVelocity;

            rb.velocity = new Vector3(hVelocity.x, rb.velocity.y, hVelocity.y);
        }
        else
        {
            hVelocity = Vector2.MoveTowards(hVelocity, Vector2.zero, friction * Time.deltaTime);
        }

        rb.velocity = new Vector3(hVelocity.x, rb.velocity.y, hVelocity.y);
    }

    private void HandleCameraControl()
    {
        _cameraLookDirection.x -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;
        _cameraLookDirection.y += Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        _cameraLookDirection.x = Mathf.Clamp(_cameraLookDirection.x, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(_cameraLookDirection.x, _cameraLookDirection.y, 0);
    }
}
