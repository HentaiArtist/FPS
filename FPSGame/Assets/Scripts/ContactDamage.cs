using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour {

    public GameObject Player;
    public float damage;

    public void OnCollisionEnter(Collision collision)


    {   GameObject victim = collision.gameObject;
        DamageSystem Dsystem = victim.GetComponent<DamageSystem>();
          
        if (victim == Player && Dsystem != null)
        {
            Dsystem.TakeContactDamage(damage);
        }
    }


}

