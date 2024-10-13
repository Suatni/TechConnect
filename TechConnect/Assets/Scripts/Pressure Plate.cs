using System;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public float requiredWeight = 10f; 
    public float currentWeight = 0f; 

    public event EventHandler OnWeightMet; 

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            currentWeight += rb.mass;
            Debug.Log("Weight added: " + rb.mass);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            currentWeight -= rb.mass;
            Debug.Log("Weight removed: " + rb.mass);
        }
    }

    private void Update()
    {
        if (currentWeight == requiredWeight)
        {
            OnWeightMet?.Invoke(this, EventArgs.Empty); 
            Debug.Log("Exact weight requirement met!");
        }
    }
}
