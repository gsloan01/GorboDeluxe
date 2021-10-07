using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Contains all data pertaining to how the player moves regardless of external forces.
    public PlayerMovementData data;
    public bool debugLogs = false;
    public bool hasGravity = true;
    public bool isMobile = true;
    public bool isActive = true;

    Vector3 gravity = new Vector3(0,-8, 0);
    public bool Sprinting { get { return sprinting; } }
    public bool Moving { get { return moving; } }
    bool sprinting, moving;
    float deadZone = 0.05f;
    float sprintTimer;

    CharacterController charController;
    PlayerControls controls;


    Vector2 move, rotate;



    private void Awake()
    {
        controls = new PlayerControls();
        charController = GetComponent<CharacterController>();

        //whenever movement is performed, set the Vector2 to the movement value and set to zero when there is no input
        controls.Gameplay.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Movement.canceled += ctx => move = Vector2.zero;

        controls.Gameplay.Rotation.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        controls.Gameplay.Rotation.canceled += ctx => rotate = Vector2.zero;

    }
    void Update()
    {
        if(isActive)
        {
            debugLogs = GameSettings.Instance.debug;

            if (isMobile)
            {
                if (sprintTimer >= data.sprintDelay && !sprinting)
                {
                    sprinting = true;
                }

                Move();
                RotateTowardsMovement();
            }
            if (hasGravity && !charController.isGrounded) Gravity();
        }
    }

    //whenever this object is enabled or disabled, do the same to the controls
    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    #region PLAYER MOVEMENT
    void Move()
    {
        
        //if going fast enough for sprinting to start, start counting until it happens
        if (Mathf.Abs(move.x) >= .4f || Mathf.Abs(move.y) >= .4f)
        {
            sprintTimer += Time.deltaTime;
        }
        else //then reset the timer because player does not fulfill the requirements to begin or continue sprinting
        {
            EndSprinting();
        }
        //if there is any input outside of the deadzone..
        if (Mathf.Abs(move.x) >= deadZone || Mathf.Abs(move.y) >= deadZone)
        {
            //move in the direction of movement                  if sprinting then go faster, else slower
            charController.Move(new Vector3(move.x, 0, move.y) * (sprinting ? data.sprintSpeed : data.speed) * Time.deltaTime);
            //if you arent considered moving, you are now
            if(!moving) moving = true;
        }
        else
        {
            //if your input has stopped, then you are not moving
            if (moving) moving = false;
        }

    }
    void Gravity()
    {
        //fall at a normal rate
        charController.Move(gravity * Time.deltaTime);
    }

    void RotateTowardsMovement()
    {
        Quaternion toRotation;
        if (Mathf.Abs(rotate.x) >= deadZone || Mathf.Abs(rotate.y) >= deadZone)
        {
            toRotation = Quaternion.LookRotation(new Vector3(rotate.x, 0, rotate.y), Vector3.up);
            //if(debugLogs) Debug.Log($"Right Stick | X : {rotate.x}, Y : {rotate.y} ");
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, data.rotateRate * Time.deltaTime);
        }
        else
        if (move != Vector2.zero)
        {
            toRotation = Quaternion.LookRotation(new Vector3(move.x, 0, move.y), Vector3.up);
            //if(debugLogs) Debug.Log($"Left Stick | X : {move.x}, Y : {move.y} ");
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, data.rotateRate * Time.deltaTime);
        }
    }

    /// <summary>
    /// This method will stop the players sprint.
    /// </summary>
    /// <param name="delay">Optional param that allows the sprint delay to be shorter or longer, Positive (+) makes the delay longer, while Negative (-) makes it shorter.</param>
    public void EndSprinting(float delay = 0.0f)
    {
        sprinting = false;
        sprintTimer = -delay;
    }
    #endregion


}
