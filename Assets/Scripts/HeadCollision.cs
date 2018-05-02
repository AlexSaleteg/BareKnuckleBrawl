using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollision : MonoBehaviour
{

    public string player;

    private float damageMult = 1.2f;
    private float damageExp = 0;
    private float timeStamp;
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
            if (Time.time <= timeStamp + 2)
            {

                damageExp++;
                Mathf.Clamp(damageExp, 0, 5);
            }
            else
            {
                Debug.Log("...");
                damageExp = 0;
            }
            if (time.timeLeft >= 0.1f)
            {
                damage.InflictDamage((int) (10 * Mathf.Pow(damageMult, damageExp)));
                time.timeLeft = +0.5f;
                //animator.SetInteger("AnimState", 4);
            }
            else
            {
                damage.InflictDamage((int)(5 * Mathf.Pow(damageMult, damageExp)));
                time.timeLeft = +0.5f;
                // animator.SetInteger("AnimState", 4);
            }
            timeStamp = Time.time;
        }
        else if (other.gameObject.tag == "HeavyFist")
        {
            if (Time.time <= timeStamp + 2)
            {
                damageExp++;
                Mathf.Clamp(damageExp, 0, 5);
            }
            else
            {
                damageExp = 0;
            }
            if (time.timeLeft >= 0.1f)
            {
                damage.InflictDamage((int)(20 * Mathf.Pow(damageMult, damageExp)));
                time.timeLeft = +0.5f;
                //animator.SetInteger("AnimState", 4);
            }
            else
            {
                damage.InflictDamage((int)(10 * Mathf.Pow(damageMult, damageExp)));
                time.timeLeft = +0.5f;
                //animator.SetInteger("AnimState", 4);
            }

            timeStamp = Time.time;
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