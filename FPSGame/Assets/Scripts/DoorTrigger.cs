using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
   DoorMovement Door;

    private void OnTriggerEnter(Collider other)
    {
       Door = GetComponentInParent<DoorMovement>();
        Door.CloseDoor();
    }
}
