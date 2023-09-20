using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public Text resourceText;

    private float currentResources;
    // Start is called before the first frame update
    void Start()
    {
        currentResources = 0f;
        UpdateUI();
    }

    // agregar recursos
    public void AddResources(float _value)
    {
        currentResources += _value;
        UpdateUI();
    }

    //quitar recursos
    public void RemoveResources(float _value)
    { 
        currentResources-=_value;
        UpdateUI();

    }


    //devolver recursos actuales
    public float CurrentResources()
    {
        return currentResources;
    }

    //funcion para actualizar el UI
    public void UpdateUI()
    {
        resourceText.text = "monke= $" + currentResources;
    }

}
