using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    public float JumpoPower;
    public void Jumpo()
    {   Camera Cum = GetComponentInChildren<Camera>();
        Rigidbody rbg = GetComponent<Rigidbody>();
        rbg.AddForce(Cum.transform.forward * JumpoPower);
    }
}
