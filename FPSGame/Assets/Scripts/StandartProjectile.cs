using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartProjectile : MonoBehaviour

{
    public float maxLifeTime ;
    public Vector3 Velocity;
    public float BulletDamage;
    public ParticleSystem prt;
    void Update()
    {
        Destroy(gameObject, maxLifeTime);
    }


    private void OnTriggerEnter(Collider other)
    { 
        GameObject coll = other.gameObject;

        if (coll.tag == "Enemy" && coll.tag != "Bullet")
        {
            DamageSystem dsystem = coll.GetComponent<DamageSystem>();
          

            if (coll.tag == "Enemy" && dsystem != null)
            {
                dsystem.TakeDamage(BulletDamage);
            }

         

        }
        prt = GetComponent<ParticleSystem>();
        prt.Play();
        Destroy(gameObject , 0.1f);
     
    }

   
}
