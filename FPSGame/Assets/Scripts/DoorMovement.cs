using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{   public Transform S;
    public Transform  F;
   
    public GameObject Door;
    public Animator Animator;
    
    public GameObject OpenClosePoint;
    public float CloseOpenTime;
    void Awake()
    {   
      //  S = Door.GetComponent<Transform>();
     //   F = OpenClosePoint.GetComponent<Transform>(); 
     //
    }
    public void CloseDoor()
    {
      //  Animator.Play("Close");
       // Door.transform.position = transform.position.Lerp(S, F, CloseOpenTime);
    }
    public void OpenDoor()
    {    //Animator.Play("Open");
        // S = F;
       //  F = S;
        // transform.position = Vector3.Lerp(S, F, CloseOpenTime);
        
    }
}
