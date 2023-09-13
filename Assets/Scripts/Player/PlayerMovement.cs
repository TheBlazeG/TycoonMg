using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float walkSpeed, runSpeed;
    public bool CanMove;

    private Vector3 vectorMovement;
    private float speed;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        speed = walkSpeed;
        vectorMovement=Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        { Walk();
            Run();
        }
    }

    void Walk()
    {//conseguimos los inputs
        vectorMovement.x = Input.GetAxis("Horizontal");
        vectorMovement.z = Input.GetAxis("Vertical");
        vectorMovement = vectorMovement.normalized;
        characterController.Move(vectorMovement * speed * Time.deltaTime);
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

    void Gravity()
    {
        //gravedad provisional
        characterController.Move(new Vector3(0f, -4f * Time.deltaTime, 0f));
    }
}
