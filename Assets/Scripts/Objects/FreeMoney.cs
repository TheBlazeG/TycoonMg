using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FreeMoney : MonoBehaviour
{
    public ResourceManager Rm;
    private void OnTriggerEnter(Collider other)
    {
        Rm.AddResources(200);
    }
}
