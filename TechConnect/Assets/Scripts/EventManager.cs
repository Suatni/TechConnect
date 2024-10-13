using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public event EventHandler OnBinsGone;

    public GameObject RedBin;
    public GameObject GreenBin;
    public GameObject BlueBin;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (!RedBin.activeInHierarchy && !GreenBin.activeInHierarchy && !BlueBin.activeInHierarchy) 
        {     
            OnBinsGone?.Invoke(this, EventArgs.Empty); 
        }
    }
}
