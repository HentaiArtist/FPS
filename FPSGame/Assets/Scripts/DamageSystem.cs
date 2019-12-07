using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DamageSystem : MonoBehaviour
{
    // взял за основу гайд с юнитидокс...   ...или не снего...   ...точно не помню
    public string SceneName;
    public Text Hp;
    public Text MaxHp;
    public float MaxHealth;                      //макс хп 
    public float CurHealth;                      //текущее хп 
    public float sinkSpeed = 2.5f;              // Скорость разложения.Первая фича с юньки , когда наш моб повержен , его труп тип удет под землю 
    public int scoreValue = 10;             // тут еще система набирания очков имееться но пока она нам не нужна    
    public AudioClip deathClip;               // Звук смэрты.

      public float score;     

    Animator Anim;                          // аниматор 
    AudioSource Audio;                      // Аудио 
    ParticleSystem hitParticles;             // Система партиклов 
    CapsuleCollider capsuleCollider;      // Коляйдер 
    bool isDead;                        // Состояние смэрты
    bool isSinking;                     // Состояние разложения
    public GameObject Player;
    

    void Awake()
    {
        // тут мы соединяем код с компонентами обьекта (хз как правильно сказать) 0_0
        Anim = GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        
        // Делаем со старта всем фулл хп , и обьявлеям кто тут батька 
        CurHealth = MaxHealth;
       
    }

    void Update()
    {

        if (isSinking)
        {
            // Если наш моб начал разлогаться то он начинает опускаться вниз
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
           // Quaternion.AngleAxis(90 , Vector3.forward);
        }

        if (Player) { 

            Hp.text = CurHealth.ToString();
            MaxHp.text = MaxHealth.ToString();
        }
        
    }


   public void TakeDamage(float damage /*Vector3 hitPoint*/)
    {

        if (isDead)
            // Если вражина померла то нефиг ей до сих пор дамаг принимать
            return;

        // играет звук принятия дамага на лицо
        Audio.Play();
        
        // Получаем дамаг
        CurHealth -= damage;

        //показываем в каком месте должен появиться партикл (тип кровушкой брызнуть , или искрами жухнуть)
       // hitParticles.transform.position = hitPoint;

        // и собственно играем партикл
        hitParticles.Play();

        // 
        if (CurHealth <= 0)
        {
            // Если хп меньше нуля то моб помирает (ДА ЛАДНО ?!!!!!!!!!!!!)
            Death();

        }
    }

    public void HealthRestore(float Heal)
    {
        CurHealth += Heal;
        if (CurHealth > MaxHealth)
        {
            CurHealth = MaxHealth;
        }
    }

  public void TakeContactDamage(float ContactDamage)
   {

      if (isDead)
       return;
       Audio.Play();
       CurHealth -= ContactDamage;
       if (CurHealth <= 0)
       {
            Death();
       }
    }



    void Death()

    {
        if (Player)
        //Если здох наш перс отправляемя на экран проигрыша
        {
            SceneManager.LoadScene(SceneName);
        }
      
        //Обьявляем состояние смэрты
        isDead = true;

        // Делаем из колайдера тригер чтобы выстрелам было пофиг на труп
        capsuleCollider.isTrigger = true;

        // ГОворим аниматору что моб помер 
        Anim.SetTrigger("Dead");

        // Меняем звук получения дамага на звук смэрты
        Audio.clip = deathClip;
        Audio.Play();
        StartSinking();
      
    }

    public void StartSinking()
    {
        // удаляем навигацию ибо трупу она уже не нужна
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        // Делаем изкинематик для риджидбади
     //   GetComponent<Rigidbody>().isKinematic = true;

        // Обявьляем что время разлогаться
        isSinking = true;

        //Тут идет начисление очков 
        score += scoreValue;

        //Дестроим моба чтобы потом и за большого количества труаов не было траблов с оптимизвцией
        Destroy(gameObject, 2f);
    }
}