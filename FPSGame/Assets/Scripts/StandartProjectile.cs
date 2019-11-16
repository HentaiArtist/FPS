using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartProjectile : MonoBehaviour

{
     Vector3  Velocity;
    public float BulletDamage;
    public GameObject range;
  


    public void OnCollisionEnter(Collision collision )
    {   
        GameObject coll = collision.gameObject;
        DamageSystem dsystem = coll.GetComponent<DamageSystem>();
        Shooting sht = GetComponentInParent<Shooting>();

        if (coll.tag == "Enemy" && dsystem != null)
        {
            dsystem.TakeDamage(BulletDamage);
        }
        else
        {
            
            GameObject gg = GetComponent<GameObject>();
            Destroy(gg);
            return;
        }
    }


    private void Update()
    {
        
        transform.position += Velocity * Time.deltaTime;

    }

}
