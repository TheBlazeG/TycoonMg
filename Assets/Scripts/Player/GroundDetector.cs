using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public float radius;
    public LayerMask detectedLayers;

    //privadas
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        checkGround();  
    }
    void checkGround()
    { isGrounded = Physics.CheckSphere(transform.position, radius, detectedLayers); }
    public bool getIsGrounded()
    { return isGrounded; }
}
