using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollision : MonoBehaviour
{

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

    //void Update()
    //{
    //    time.timeLeft -= Time.deltaTime;
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LightFist")
        {
            if (time.timeLeft >= 0.1f)
            {
                damage.InflictDamage(10);
                time.timeLeft = +0.5f;
                //animator.SetInteger("AnimState", 4);
            }
            else
            {
                damage.InflictDamage(5);
                time.timeLeft = +0.5f;
               // animator.SetInteger("AnimState", 4);
            }
        }
        else if (other.gameObject.tag == "HeavyFist")
        {
            if (time.timeLeft >= 0.1f)
            {
                damage.InflictDamage(20);
                time.timeLeft = +0.5f;
                //animator.SetInteger("AnimState", 4);
            }
            else
            {
                damage.InflictDamage(10);
                time.timeLeft = +0.5f;
                //animator.SetInteger("AnimState", 4);
            }
        }
        if (time.chargeTimer >= 10)
        {
           damage.InflictDamage(30);
           time.chargeTimer = 0;
        }
        //if (time.timeLeft <= 0.1f)
        //{
        //    animator.SetInteger("AnimState", 0);
        //}
    }
}

