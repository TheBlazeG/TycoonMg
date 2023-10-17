using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    //Public Variables
    public PlayerMovement playerMovement;
    public GroundDetector groundDetector;

    //Private variables
    private float speed;
    private bool isGrounded;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0f;
        isGrounded = true;
        animator = GetComponent <Animator>() ;
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();
        CheckSpeed();
        SetParameters();
    }
    void SetParameters()
    {
        animator.SetFloat("Speed",speed);
        animator.SetBool("IsGrounded", isGrounded);
    }
    public void CheckSpeed()
    {
        speed = playerMovement.GetCurrentSpeed();
    }
    public void CheckGrounded()
    {
        isGrounded = groundDetector.getIsGrounded();
    }
}
