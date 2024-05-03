using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[Header("What player is looking at")]
    
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public Transform orientation;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJmp = true;

    public float horizontalInput;
    public float verticalInput;

    public Vector3 moveDirection;

    Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        //worldLayer_1 = LayerMask.NameToLayer("whatIsGround");
        //Debug.Log(worldLayer_1.value);
    }

    [Header("Ground Check")]

    public float playerHeight;
    bool grounded;
    public LayerMask worldLayer_1;

    public GameObject wayPoint;
    private float timer = 0.5f;

    private void Update()
    {
        MyInput();
        SpeedControl();


        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, worldLayer_1);
        //Debug.DrawRay(transform.position, Vector3.down *2, Color.yellow);

        if (grounded)
        {
            rb.drag = groundDrag;
            //Debug.Log("player on a floor");

        }
        else
        {
            rb.drag = 0;
            //Debug.Log("player not on a floor");

        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            //The position of the waypoint will update to the player's position
            UpdatePosition();
            timer = 0.5f;
        }
    }

    public bool IsCameraOn = false;

    void UpdatePosition()
    {
        //The wayPoint's position will now be the player's current position.
        wayPoint.transform.position = transform.position;
    }

    private void FixedUpdate()
    {
        
        if(!IsCameraOn)
            MovePlayer();
        
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && readyToJmp && grounded)
        {
            readyToJmp = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJmp = true;
    }

}
