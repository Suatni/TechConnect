using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redInteract : MonoBehaviour
{
    public GameObject Bin;
    public GameObject Ball;


    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject == Bin)
        {
            Bin.SetActive(false);
            Ball.SetActive(false);
        }
    }

}
