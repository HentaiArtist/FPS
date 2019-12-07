using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour {
    DamageSystem Dsystem;
    Shooting Sht;
    public float HealPower;
    public int Ammo;
    public GameObject PickUp;
    public bool recovering;
	
	
   
     // void Update () {
       // switch (recovering)
     //   {
      //      case Start:;
      //  }


  //  }
   void OnTriggerEnter (Collider character )
    {   GameObject GO = character.gameObject;
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
   // recovering = true;

    }

  //  private void OnTriggerExit(Collider other)
   // {
 ////       recovering = false;
  //  }
  
}
