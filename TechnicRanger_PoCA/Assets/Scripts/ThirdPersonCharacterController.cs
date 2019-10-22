using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPersonCharacterController : MonoBehaviour
{

    /*protected CharacterController characterController;

    protected Vector3 movement;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        if (characterController == null)
            throw new UnityException("No Character Controller attached to capsule.");
    }

    void Update()
    {

        if (characterController.isGrounded == true)
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            movement = transform.TransformDirection(movement);
            movement *= 5.0f;

            if (Input.GetKey(KeyCode.Space) == true)
                movement.y = 10.0f;
        }

        movement.y -= 20.0f * Time.deltaTime;

        characterController.Move(movement * Time.deltaTime);
    }*/

    //---------------------------------------------------------------------------------------------

    public float InputX, InputZ;
    public Vector3 desiredMoveDirection;
    public float desiredRotationSpeed;

    public float Speed;
    public Vector3 jump;
    public float jumpForce;

    public bool isGrounded;
    Rigidbody rb;

    public Camera cam;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jumpForce, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver).normalized * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

        /*InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * InputZ + right * InputX;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection.normalized), desiredRotationSpeed);


        //moveVector = new Vector3(0, verticalVel, 0).normalized;
        //Speed = new Vector2(InputX, InputZ).normalized.sqrMagnitude;
        //transform.Translate(desiredMoveDirection, Space.World);*/

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (Input.GetKeyDown("l"))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

//----------------------------------------------------------------------------------------------------------------------

/*public float InputX, InputZ;
public Vector3 desiredMoveDirection;
public bool blockRotationPlayer;
public float desiredRotationPlayer;
public float desiredRotationSpeed;
public float Speed;
public float allowPlayerRotation;
public Camera cam;
public CharacterController controller;
public bool isGrounded;
private float verticalVel;
private Vector3 moveVector;

void Start()
{
    cam = Camera.main;
    controller = this.GetComponent<CharacterController>();
}

void Update()
{
    InputMagnitude();

    isGrounded = controller.isGrounded;//here to
    if (isGrounded)
    {
        verticalVel -= 0;
    }
    else
    {
        verticalVel -= 2;
    }
    moveVector = new Vector3(0, verticalVel, 0);
    controller.Move(moveVector);//here


}

void PlayerMoveAndRotation()
{
    InputX = Input.GetAxis("Horizontal");
    InputZ = Input.GetAxis("Vertical");

    var camera = Camera.main;
    var forward = cam.transform.forward;
    var right = cam.transform.right;

    forward.y = 0f;
    right.y = 0f;
    forward.Normalize();
    right.Normalize();

    desiredMoveDirection = forward * InputZ + right * InputX;

    if(blockRotationPlayer == false)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
    }
}

void InputMagnitude()
{
    //calculate the input vectors
    InputX = Input.GetAxis("Horizontal");
    InputZ = Input.GetAxis("Vertical");


}*/
}
