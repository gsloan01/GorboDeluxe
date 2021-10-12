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

    [SerializeField]
    Camera camera;

    Vector3 gravity = new Vector3(0,-8, 0);
    public bool Sprinting { get { return sprinting; } }
    public bool Moving { get { return moving; } }
    bool sprinting, moving;
    float deadZone = 0.05f;
    float sprintTimer;

    CharacterController charController;
    Player thisPlayer;
    PlayerInputHandler input;

    Vector2 move, rotate, mousePos;



    private void Awake()
    {
        charController = GetComponent<CharacterController>();

        thisPlayer = GetComponent<Player>();
        data = thisPlayer.PlayerData.movementData;
        input = thisPlayer.inputHandler;

    }
    void Update()
    {

        if(isActive)
        {
            move = input.Movement;
            if(input.GP_Active) rotate = input.StickRotation;

            if (input.MK_Active) mousePos = input.MousePos;

            debugLogs = GameSettings.Instance.debug;
            if (isMobile)
            {
                if (sprintTimer >= data.sprintDelay && !sprinting)
                {
                    sprinting = true;
                }

                MovementHandling();
                RotationHandling();
            }
            if (hasGravity && !charController.isGrounded) Gravity();
        }
    }

    #region PLAYER MOVEMENT
    void MovementHandling()
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
    Vector3 hitpoint;
    void RotationHandling()
    {
        Quaternion toRotation;
        //if gamepad controls
        if(input.GP_Active)
        {
            if (Mathf.Abs(rotate.x) >= deadZone || Mathf.Abs(rotate.y) >= deadZone)
            {
                SetLookRotation(rotate);
            }
            else if(move != Vector2.zero)
            {
                SetLookRotation(move);
            }
        }
        else if(input.MK_Active)
        {
            if(mousePos != Vector2.zero)
            {
                //Gets the world position from the camera
                Vector2 mouseToWorldXZ = Vector2.zero;

                Ray ray = camera.ScreenPointToRay(mousePos);
                if(Physics.Raycast(ray, out RaycastHit hitinfo, 1000))
                {
                    hitpoint = hitinfo.point;

                    //Gets the XZ of that position
                    //Character rotates towards that point
                    //hitpoint = transform.worldToLocalMatrix.MultiplyVector(hitpoint);
                    Vector3 direcVec3 = hitpoint - transform.position;
                    Vector2 direction = new Vector2(direcVec3.x, direcVec3.z);
                    

                    toRotation = Utility.GetLookRotationFromVec2(direction);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, data.rotateRate * Time.deltaTime);
                }
                else
                {
                    SetLookRotation(move);
                }
                
            } else
            if (move != Vector2.zero)
            {
                SetLookRotation(move);
            }
        }
        
    }
    void SetLookRotation(Vector2 v)
    {
        Quaternion toRotation;
        toRotation = Utility.GetLookRotationFromVec2(v);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, data.rotateRate * Time.deltaTime);
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(hitpoint, .2f);
    }

}
