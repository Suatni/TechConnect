using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class InteractableObject : MonoBehaviour
{
    public bool playerInRange;

    public string ItemName;
    public TMP_Text weightText; 

    private float totalMass; 

    private void Start()
    {
        if (weightText != null)
        {
            weightText.gameObject.SetActive(false);
        }
        totalMass = 0f; 
    }

    public string GetItemName()
    {
        return ItemName;
    }

    private void Update()
    {
        if (playerInRange && weightText != null)
        {
            weightText.text = "Current Mass: " + totalMass.ToString("F2") + " kg"; 
            weightText.gameObject.SetActive(true); 
        }
        else if (weightText != null)
        {
            weightText.gameObject.SetActive(false); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            playerInRange = true;
            totalMass += rb.mass; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            totalMass -= rb.mass; 
            if (totalMass < 0) 
            {
                totalMass = 0;
            }
        }

        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}

