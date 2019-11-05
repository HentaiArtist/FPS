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

public class Shooting : MonoBehaviour
{
    public float LastShot;
    public GameObject Projectile;
    public int BulletsPerShot;
    public WeaponShootType shootType;
    public GameObject projectile;          
    public GameObject Gun;
    public int damagePerShot;
    public float RayLifeTime;
    public float range;
    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
    public AudioClip ShootSound;
    public AudioClip ReloadSound;
    public int AmmoCount;
    public int CurAmmo;
    public int Clip;
    public Text Ammotext;
    public Text AmmoCounttext;
    public Transform Gunslot;
    public Transform ProjectileSpawn;
    public int MaxAmmo;
    public float delayBetweenShots;

    void Awake()
    {

        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        AmmoCount = MaxAmmo;

    }

    void Update()
    {

      //  if ( ) {
            Ammotext.text = CurAmmo.ToString();
            AmmoCounttext.text = AmmoCount.ToString();
          //     }
      //  timer += Time.deltaTime;
        //if (Input.GetKeyDown(ReloadKey) && AmmoCount != 0 )
        //{
        // Reload();
        // }
        //if (Input.GetMouseButtonDown(0) && && AmmoCount!= 0 && CurAmmo != 0 && Gun.transform.position == Gunslot.transform.position)
        //  {
        // Shoot();
        // }

        if (timer >= RayLifeTime * effectsDisplayTime)
        {
            DisableEffects();
        }
    }
    
    
       


    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    public bool ShootInputType(bool inputDown, bool inputHeld, bool inputUp)
    {
        switch (shootType)
        {
            case WeaponShootType.MANUAL:
                if (inputDown)
                {
                    return TryShoot();
                }
                return false;

            case WeaponShootType.AUTO:
                if (inputHeld)
                {
                    return TryShoot();
                }
                return false;

            case WeaponShootType.CHARGE:
                if (inputHeld)
                {
                    TryBeginCharge();
                }
                if (inputUp)
                {
                    return TryReleaseCharge();
                }
                return false;

            default:
                return false;
        }
    }

    public bool TryShoot()
    {
        Shoot();
    }

    public bool TryBeginCharge()
    {
        
    }

    public bool TryReleaseCharge()
    {
        
    }   

    public void Shoot()
    {

        if (CurAmmo != 0 && AmmoCount != 0 && LastShot + delayBetweenShots < Time.time)
         {


            for (int i = 0; i < BulletsPerShot; i++)
            {
                Vector3 shotDirection = ProjectileSpawn.position;
                Instantiate(Projectile, ProjectileSpawn.position, Quaternion.LookRotation(shotDirection));
            }

          
            LastShot = Time.time;

           
            if (ShootSound)
            {
                gunAudio.PlayOneShot(ShootSound);
            }





            /* timer = 0f;
             gunAudio.Play();
             gunLight.enabled = true;
             gunParticles.Stop();
             gunParticles.Play();
             gunLine.enabled = true;
             gunLine.SetPosition(0, transform.position);
             shootRay.origin = transform.position;
             shootRay.direction = transform.forward;
             CurAmmo -= 1;

             if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
             {

                 DamageSystem Dsystem = shootHit.collider.GetComponent<DamageSystem>();

                 if (Dsystem != null)
                 {

                     Dsystem.TakeDamage(damagePerShot, shootHit.point);
                 }
                 gunLine.SetPosition(1, shootHit.point);
             }
             else
             {
                 gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
             }*/


        }
    }

        
    
    public void Aiming()
    {
        
    }

    public void  Notaiming()
    {
       
    }

        public void Reload()
    {
        if (CurAmmo != Clip && AmmoCount > 0)
        {
            AmmoCount -= Clip;
            CurAmmo = Clip;
        }
        
           // Ammotext.text = CurAmmo.ToString();
         //  AmmoCounttext.text = AmmoCount.ToString();
        

    }

    public void AmmoRestore(int AmmoFromPickUp)
    {
        if (AmmoCount != MaxAmmo)
        {
            AmmoCount += AmmoFromPickUp;
        }
        else return;
    }

    

}
    
 
   

		
	

