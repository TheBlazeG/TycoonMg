using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDetector : MonoBehaviour
{
    // Start is called before the first frame update


    public ResourceManager resourceManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Resource>())
        {
            resourceManager.AddResources(other.gameObject.GetComponent<Resource>().value);
            Destroy(other.gameObject);
        }
    }

}
