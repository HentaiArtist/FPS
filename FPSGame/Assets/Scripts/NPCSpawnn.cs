using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawnn : MonoBehaviour
{
    public GameObject NPC;
    public Transform Spawn;
   

   public void spawn()
    {
        Instantiate(NPC,Spawn.position,Quaternion.identity);
        
    }
   
}
