using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    void Start()
    {
        
    }

    void OnMouseEnter()
    {
        Red();
    }
    void OnMouseExit()
    {
        Yellow();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Green();
        }
        else
        {
            Red();
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        Yellow();
    }
    public void Red()
    {
        GetComponent<Renderer>().material.color = Color.red;
        Debug.Log("Cube turn RED");
    }
    public void Yellow()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
        Debug.Log("Cube turn Yellow");
    }
    public void Green()
    {
        GetComponent<Renderer>().material.color = Color.green;
        Debug.Log("Cube turn GREEN");
    }
}
