using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDropper : MonoBehaviour
{
    //variables publicas
    public GameObject[] resources;
    public float SpawnTime;

    //privadas
    private int dropperTier;
    // Start is called before the first frame update
    void Start()
    {
        dropperTier = 1;
        InvokeRepeating("DropResource",SpawnTime,SpawnTime);
    }

    //Instanciar un recurso
    void DropResource()
    {
        if (resources[dropperTier-1] !=null||dropperTier<=resources.Length)
        {
            Instantiate(resources[dropperTier - 1], transform.position, Quaternion.identity);
        } }

    //funcion para mejorar el recurso
    public void UpgradeDropper()
    { dropperTier++; }
}
