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
    public float AmmoNeededToStartCharge;
    public bool IsCharge;
    public float LastShot;
    public GameObject Projectile;
    public int BulletsPerShot;
    public WeaponShootType shootType;
    public float currentCharge { get; private set; }
    public GameObject Gun;
    public float RayLifeTime;
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

    void Awake()
    {


        gunParticles = GetComponent<ParticleSystem>();

        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        AmmoCount = MaxAmmo;

    }

    void Update()
    {

        // if (transform.position == Gunslot ) {
        Ammotext.text = CurAmmo.ToString();
        AmmoCounttext.text = AmmoCount.ToString();
        //    }


        if (timer >= RayLifeTime * effectsDisplayTime)
        {
            DisableEffects();
        }
    }





    public void DisableEffects()
    {

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

    public bool TryBeginCharge()
    {
        if (!IsCharge && CurAmmo >= AmmoNeededToStartCharge && LastShot + delayBetweenShots < Time.time)
        {
            UseAmmo(AmmoNeededToStartCharge);
            IsCharge = true;

            return true;

        }
        return false;
    }
    public bool TryReleaseCharge()
    {
        if (IsCharge)
        {
            Shoot();

            currentCharge = 0f;
            IsCharge = false;

            return true;
        }
        return false;
    }

    public void Shoot()
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
}
    


    
 
   

		
	

