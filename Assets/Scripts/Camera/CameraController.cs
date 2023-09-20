using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensibility;
    public Transform CameraJointY, targetObject;
    public bool canRotate;
    private float xRotation, yRotation;
    void Start()
    {
        canRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate)
        {
            Rotate();
        }
        FollowTarget();
    }
    void Rotate()
    {
        xRotation += Input.GetAxis("Mouse X") * Time.deltaTime * sensibility;
        yRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * sensibility;


        yRotation = Mathf.Clamp(yRotation, -65, 65);

        transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
        CameraJointY.transform.localRotation = Quaternion.Euler(-yRotation, 0f, 0f);
    }

    void FollowTarget()
    {
        transform.position = targetObject.position;
    }
}
