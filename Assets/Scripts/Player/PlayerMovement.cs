using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform CameraAim;
    public float walkSpeed, runSpeed, rotationSpeed, jumpForce;
    public bool CanMove;

    private Vector3 vectorMovement, verticalForce;
    private float speed,currentSpeed;
    private bool isGrounded;
    private CharacterController characterController;
    public GroundDetector groundDetector;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        speed = 0f;
        currentSpeed = 0f;
        vectorMovement = Vector3.zero;
        verticalForce = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        { Walk();
            Run();
            alignPlayer();
            Jump();
        }
        Gravity();
        CheckGround();
    }

    void Walk()
    {//conseguimos los inputs
        vectorMovement.x = Input.GetAxis("Horizontal");
        vectorMovement.z = Input.GetAxis("Vertical");
        //normalizamos el vector de movimiento 
        vectorMovement = vectorMovement.normalized;
        //nos movemos con direccion a la camara
        vectorMovement = CameraAim.TransformDirection(vectorMovement);
        //velocidad actual con suavizado
        currentSpeed = Mathf.Lerp(currentSpeed, vectorMovement.magnitude * speed, 10f*Time.deltaTime);
        characterController.Move(vectorMovement * currentSpeed * Time.deltaTime);

    }

    void Run()
    {
        //si presionamos el boton alteramos velocidad
        if (Input.GetAxis("Run") > 0f)
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }

    void Jump()
    {
        if (isGrounded && Input.GetAxis("Jump")>0f)
        {
            verticalForce = new Vector3(0f, jumpForce, 0f);
            isGrounded = false;
        } 
    }

    void Gravity()
    {
        //si no estamos tocando el suelo
        if (!isGrounded)
        {
            verticalForce += Physics.gravity * Time.deltaTime;
        }
        else
        { 
            verticalForce = new Vector3(0f, -2f, 0f); 
        }
        characterController.Move(verticalForce * Time.deltaTime);
    }

    void alignPlayer()
    {
        if (characterController.velocity.magnitude > 0f)
        {

            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(vectorMovement), rotationSpeed * Time.deltaTime);
            }

        }
    }
    void CheckGround()
    { isGrounded = groundDetector.getIsGrounded(); }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
}
