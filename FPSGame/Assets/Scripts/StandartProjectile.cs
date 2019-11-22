using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartProjectile : MonoBehaviour

{
    public float maxLifeTime ;
    public Vector3 Velocity;
    public float BulletDamage;
        
    void Update()
    {
       // Destroy(gameObject, maxLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject coll = other.gameObject;
        GameObject gg = GetComponent<GameObject>();
        if (coll.tag == "Enemy" && gg.tag != "Bullet")
        {
            DamageSystem dsystem = coll.GetComponent<DamageSystem>();
            Shooting sht = GetComponentInParent<Shooting>();

            if (coll.tag == "Enemy" && dsystem != null)
            {
                dsystem.TakeDamage(BulletDamage);
            }

            Destroy(gg);
            return;
        }
    }

   
}
