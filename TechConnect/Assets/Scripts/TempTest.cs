using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TempTest : MonoBehaviour
{
    private void Start()
    {
        EventManager BinsGoneTest = GetComponent<EventManager>();
        BinsGoneTest.OnBinsGone += Testing_OnBinsGone;
    }

    private void Testing_OnBinsGone(object sender, EventArgs e)
    {
        Debug.Log("All Balls gathered");
    }
}
