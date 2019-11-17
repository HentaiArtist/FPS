using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawn : MonoBehaviour
{   
    NPCSpawnn npc;
 public GameObject Trigger;
    private void OnTriggerEnter(Collider other)
    {
        npc = GetComponentInParent<NPCSpawnn>();
        npc.spawn();
        Trigger.SetActive(false);
    }
}
