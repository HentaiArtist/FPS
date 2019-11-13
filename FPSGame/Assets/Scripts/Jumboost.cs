using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumboost : MonoBehaviour
{
    public GameObject PLayer;
    public float boostpower;


    public void boost()
    {
        Rigidbody rbg = PLayer.GetComponent<Rigidbody>();
        Camera cum = PLayer.GetComponent<Camera>();
        

    }
}
