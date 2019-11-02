using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shooting : MonoBehaviour
{



    // оч много тупо перепечатал с гайдов но я хочу спать и у меня дз не деланое надеюсь разберетесь 
  
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
    public KeyCode ReloadKey;
    public AudioClip ReloadSound;
    public int AmmoCount;
    public int CurAmmo;
    public int Clip;
    public Text Ammotext;
    public Text AmmoCounttext;
    public Transform Gunslot;
    public float AIMPower;
    public int MaxAmmo;
    public float ASpeed;
    public float UnASpeed;
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
        
        
            Ammotext.text = CurAmmo.ToString();
            AmmoCounttext.text = AmmoCount.ToString();
        
        timer += Time.deltaTime;
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

    public void Shoot()
    {
        if (CurAmmo != 0 && AmmoCount != 0  )
        {
            timer = 0f;
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
            }

        }
    }
    public void Aiming()
    {
        Aiming cum = GetComponentInParent<Aiming>();
        cum.Aim(AIMPower, ASpeed);
    }

    public void  Notaiming()
    {
        Aiming cum = GetComponentInParent<Aiming>();
        cum.Notaim(AIMPower, UnASpeed);
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
    
 
   

		
	

