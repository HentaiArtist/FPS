using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum WeaponShootType
{
    CHARGE,
    AUTO,
    MANUAL
}

public class Shooting : MonoBehaviour { 
         
    
    public float SpreadX;
  


    public float SpreadY;
    

    public float SpreadZ;
  

    public float AimPower;
    public bool isfiring;
    public bool isCharging;
    public float ChargeDuration;
    public float AmmoUsedInCharge;
    public float AmmoNeededToStartCharge;
    public bool IsCharge;

    public float LastShot;
    public GameObject Projectile;
    public int BulletsPerShot;
    public WeaponShootType shootType;
    public float currentCharge { get; private set; }

    public GameObject Gun;
   
    float timer;

    ParticleSystem gunParticles;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
    public AudioClip ShootSound;
    public AudioClip ReloadSound;

    public float AmmoCount;
    public float CurAmmo;
    public float Clip;
    public Text Ammotext;
    public Text AmmoCounttext;
    public Transform Gunslot;
    public Transform ProjectileSpawn;
    public int MaxAmmo;
    public float delayBetweenShots;
    public float BulletSpeed;

 
void Awake()
{


    gunParticles = GetComponent<ParticleSystem>();

    gunAudio = GetComponent<AudioSource>();
    gunLight = GetComponent<Light>();
    AmmoCount = MaxAmmo;
}
  
    void Update()
    {
        switch (shootType)
        {
            case WeaponShootType.MANUAL:    break  ;
             
            case WeaponShootType.AUTO:
                if (isfiring)
                {
                    LastShot += Time.deltaTime;
                    if (LastShot > delayBetweenShots)
                    {
                        TryShoot();
                    }
                }
                break;
                
                
            case WeaponShootType.CHARGE:
                ChargeDuration += Time.deltaTime;
                break;

        }

        Ammotext.text = CurAmmo.ToString();
        AmmoCounttext.text = AmmoCount.ToString();
    }
    
       
   public void DisableEffects()
    {

        gunLight.enabled = false;
    }

  
   
    public bool TryShoot()
    {
        if (CurAmmo != 0 && AmmoCount != 0 && LastShot + delayBetweenShots < Time.time)
        {
            Shoot();
            return true;
        }
        return false;
    }

    public void UseAmmo(float amount)
    {
        CurAmmo = Mathf.Clamp(CurAmmo - amount, 0f, Clip);
        LastShot = Time.time;
    }

    
 

    public void Shoot()
    {
         CurAmmo -= 1; 
        for (int i = 0; i < BulletsPerShot; i++)
        {
            //Camera Cum = GetComponentInChildren<Camera>();

         //    ProjectileSpawn.transform.position = new Vector3(Random.Range(-SpreadX , SpreadX ), Random.Range(-SpreadY, SpreadY), Random.Range(-SpreadZ, SpreadZ) );


            Quaternion BulletLook = Camera.main.transform.rotation;
            GameObject go =  Instantiate(Projectile, ProjectileSpawn.position, BulletLook );
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.velocity = Camera.main.transform.forward * BulletSpeed;
           
        }
        
        LastShot = 0;

        if (ShootSound)
        {
            gunAudio.PlayOneShot(ShootSound);
        }
    }

    public void Reload()
    {
        if (CurAmmo != Clip && AmmoCount > 0)
        {
            AmmoCount -= Clip;
            CurAmmo = Clip;
        }



    }

    public void AmmoRestore(int AmmoFromPickUp)
    {
        if (AmmoCount != MaxAmmo)
        {
            AmmoCount += AmmoFromPickUp;
        }
        else return;
    }

    public void Use()
    {
        switch (shootType)
        {
            case WeaponShootType.AUTO:
                isfiring = true;
                break;

            case WeaponShootType.CHARGE:
                ChargeDuration = 0;
                break;

            case WeaponShootType.MANUAL:
                TryShoot();
                break;
        }

    }

    public void Enduse()
    {
        switch (shootType)
        {
            case WeaponShootType.AUTO:
                isfiring = false;
                break;

            case WeaponShootType.CHARGE:
                // TODO: Shoot charges
                ChargeDuration = 0;
                break;

            case WeaponShootType.MANUAL:
                break;
        }

    }

 
}
    


    
 
   

		
	

