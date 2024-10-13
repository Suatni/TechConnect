using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public event EventHandler OnBinsGone;
    public event EventHandler OnWeightMet;

    public GameObject RedBin;
    public GameObject GreenBin;
    public GameObject BlueBin;
    public PressurePlate pressurePlate;

    private bool weightMet = false;

    private void Start()
    {
        if (pressurePlate != null)
        {
            pressurePlate.OnWeightMet += HandleWeightMet;
        }
    }

    private void Update()
    {
        if (!RedBin.activeInHierarchy && !GreenBin.activeInHierarchy && !BlueBin.activeInHierarchy) 
        {     
            OnBinsGone?.Invoke(this, EventArgs.Empty); 
        }
    }

    private void HandleWeightMet(object sender, EventArgs e)
    {
        weightMet = true;
        OnWeightMet?.Invoke(this, EventArgs.Empty);
        Debug.Log("Weight requirement met!");
    }

    public bool IsEventCompleted()
    {
        return weightMet;
    }
}

