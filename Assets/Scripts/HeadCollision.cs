using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollision : MonoBehaviour {

    public string player;
    private TakeDamage damage;
    private Animator animator;
    private AnimationScript time;
    void Start()
    {
        time = GameObject.Find(player).GetComponent<AnimationScript>();
        animator = GameObject.Find(player).GetComponent<Animator>();
        damage = GameObject.Find(player).GetComponent<TakeDamage>();
       
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LightFist")
        {
            damage.InflictDamage(10);
            time.timeLeft = +0.5f;
            animator.Play("Stagger");
           
        }
        else if (other.gameObject.tag == "HeavyFist")
        {
            damage.InflictDamage(20);
            time.timeLeft = +0.5f;
            animator.Play("Stagger");
           
        }
        
    }
}
