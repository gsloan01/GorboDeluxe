using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region Public Properties
    #region bools
    public bool debugLogs = false;
    public bool hasGravity = true;
    #endregion
    #region floats
    public float speed = 5;
    public float sprintSpeed = 7;
    public float rotateRate = 720f;
    public float sprintDelay = 3.0f;
    #endregion
    #endregion

    #region Private Members
    CharacterController charController;
    PlayerControls controls;
    float deadZone = 0.05f;
    float sprintTimer;
    bool sprinting;

    Vector2 move;
    Vector2 rotate;
    #endregion

    private void Awake()
    {
        controls = new PlayerControls();
        charController = GetComponent<CharacterController>();

        controls.Gameplay.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Movement.canceled += ctx => move = Vector2.zero;

        controls.Gameplay.Rotation.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        controls.Gameplay.Rotation.canceled += ctx => rotate = Vector2.zero;
    }
    void Update()
    {
        if (sprintTimer >= sprintDelay && !sprinting)
        {
            sprinting = true;
        }

        debugLogs = GameSettings.Instance.debug;

        Move();
        if(hasGravity) Gravity();
        Rotate();
    }

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
        
        if (Mathf.Abs(move.x) >= .4f || Mathf.Abs(move.y) >= .4f)
        {
            sprintTimer += Time.deltaTime;
        }
        else
        {
            sprintTimer = 0;
            sprinting = false;
        }
        //if there is any input outside of the deadzone..
        if (Mathf.Abs(move.x) >= deadZone || Mathf.Abs(move.y) >= deadZone)
        {
            //move in the direction of movement
            charController.Move(new Vector3(move.x, 0, move.y) * (sprinting ? sprintSpeed : speed) * Time.deltaTime);
            
        }
    }
    void Gravity()
    {
        Vector3 gravity = new Vector3(0, charController.isGrounded ? 0 : -8 * Time.deltaTime, 0);
        
        charController.Move(gravity);
    }

    void Rotate()
    {
        Quaternion toRotation;
        if (Mathf.Abs(rotate.x) >= deadZone || Mathf.Abs(rotate.y) >= deadZone)
        {
            toRotation = Quaternion.LookRotation(new Vector3(rotate.x, 0, rotate.y), Vector3.up);
            //if(debugLogs) Debug.Log($"Right Stick | X : {rotate.x}, Y : {rotate.y} ");
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateRate * Time.deltaTime);
        }
        else
        if (move != Vector2.zero)
        {
            toRotation = Quaternion.LookRotation(new Vector3(move.x, 0, move.y), Vector3.up);
            //if(debugLogs) Debug.Log($"Left Stick | X : {move.x}, Y : {move.y} ");
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateRate * Time.deltaTime);
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
