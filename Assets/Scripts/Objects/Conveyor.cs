using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed;
    private Vector3 movementVector;
    // Start is called before the first frame update
    void Start()
    {
        movementVector = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Resource"))
        {
            Transform collidedObject = collision.gameObject.transform;
            collidedObject.position = new Vector3(collidedObject.position.x + movementVector.x * Time.deltaTime, collidedObject.position.y + movementVector.y * Time.deltaTime, collidedObject.position.z + movementVector.z * Time.deltaTime);
        }
    }
}
