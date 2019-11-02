using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CameraState
{
    NOTAIMING,
    AIMING
}
public class Aiming : MonoBehaviour
{

    // public Animator animator;
    //public GameObject Player;
    public CameraState State { get; set; }


    public void Aim(float AimPower , float AimSpeed)
    {
        Camera cum = GetComponent<Camera>();
        if (State == CameraState.NOTAIMING)
        {  
            
            State = CameraState.AIMING;
            cum.fieldOfView = Mathf.Lerp(cum.fieldOfView, cum.fieldOfView - AimPower, AimSpeed);
        }
    }
    public void Notaim(float AimPower , float UnAimSpeed)
    {
        
        Camera cum = GetComponent<Camera>();
        
        if (State == CameraState.AIMING)

        { 
            State = CameraState.NOTAIMING;
            cum.fieldOfView = Mathf.Lerp(cum.fieldOfView, cum.fieldOfView + AimPower,UnAimSpeed ) ;
            

        }
    }
}




