using System;
using UnityEngine;

public class PressurePlateEventManager : MonoBehaviour
{
    public event EventHandler OnWeightMet;

    public PressurePlate pressurePlate;

    private void Start()
    {
        if (pressurePlate != null)
        {
            pressurePlate.OnWeightMet += HandleWeightMet;
        }
    }

    private void HandleWeightMet(object sender, EventArgs e)
    {
        OnWeightMet?.Invoke(this, EventArgs.Empty);
        Debug.Log("Pressure plate requirement met!");
    }

    private void OnDestroy()
    {
        if (pressurePlate != null)
        {
            pressurePlate.OnWeightMet -= HandleWeightMet;
        }
    }
}
