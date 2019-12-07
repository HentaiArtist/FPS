using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meele : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Atack()
    {
        animator.Play("Atack");
    }

    public void HeavyAtack()
    {
        animator.Play("HeavyAtack");
    }
}
