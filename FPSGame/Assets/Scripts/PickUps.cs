using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour {
    DamageSystem Dsystem;
    Shooting Sht;
    public float HealPower;
    public int Ammo;
    public GameObject PickUp;
	
	void Start () {
     
	}

    public void OnTriggerEnter (Collider character )
    {
        GameObject GO = character.gameObject;
        Dsystem = GO.GetComponent<DamageSystem>();
        Sht = GO.GetComponentInChildren<Shooting>();

       
        if (PickUp.tag == "Hp"  && Dsystem !=null  )
        {
            Dsystem.HealthRestore(HealPower);
        }

        if (PickUp.tag == "Ammo"&& Sht != null )
        {
           
            Sht.AmmoRestore(Ammo);

        }

        else return;

    }
    void Update () {
		
	}
}
