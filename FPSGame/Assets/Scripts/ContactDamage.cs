using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour {

  //  public GameObject Player;
    public float damage;
//   public Animation atack;


    public void Atack()
    {
       // atack.Play();
    }

    public void OnCollisionEnter(Collision collision)


    {   GameObject victim = collision.gameObject;
        DamageSystem Dsystem = victim.GetComponent<DamageSystem>();
          
        if (victim.tag == "Enemy" && Dsystem != null)
        {
            Dsystem.TakeContactDamage(damage);
        }
    }


}

