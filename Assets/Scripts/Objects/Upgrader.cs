using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Upgrader : MonoBehaviour
{
    // Start is called before the first frame update
    public ResourceManager resourceManager;
    public float cost;
    public string text;
    public UnityEvent OnActivated;

    private TextMesh textMesh;
    void Start()
    {
        textMesh = GetComponentInChildren<TextMesh>();

        //ponemos el texto y el costo
        textMesh.text = text +"$"+ cost;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (resourceManager.CurrentResources()>=cost)
            {
                //quitamos costo de la mejora, activamos el evento y nos destruimos
                resourceManager.RemoveResources(cost);
                OnActivated.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
