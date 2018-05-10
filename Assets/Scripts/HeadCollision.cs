using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollision : MonoBehaviour
{
    private AnimationScript1 player_2;
    private AnimationScript1 player_1;
    private string player;
    private float damageMult = 1.2f;
    private float damageExp = 0;
    private float timeStamp;
    private TakeDamage damage;
    private Animator animator;
    private AnimationScript1 time;
    private TimerScript roundEnd;
    public int lightcomboDmg;
    public int lightguardlessDmg;
    public int lightguardDmg;
    public int slapDmg;
    public int heavycomboDmg;
    public int heavyguardlessDmg;
    public int heavyguardDmg;
    public int chargeDmg;

    [HideInInspector]
    public float leastAountofTime;
    void Start()
    {
        player = transform.root.name;
        player_1 = GameObject.Find("Player1").GetComponent<AnimationScript1>();
        player_2 = GameObject.Find("Player2").GetComponent<AnimationScript1>();
        time = GameObject.Find(player).GetComponent<AnimationScript1>();
        animator = GameObject.Find(player).GetComponent<Animator>();
        damage = GameObject.Find(player).GetComponent<TakeDamage>();
        roundEnd = GameObject.Find("RoundTimer").GetComponent<TimerScript>();
        leastAountofTime = 0.001f;
        lightcomboDmg = 10;
        lightguardlessDmg = 5;
        lightguardDmg = 2;

    }

    //void Update()
    //{
    //    time.timeLeft -= Time.deltaTime;
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LightFist" && roundEnd.PauseTimer <= leastAountofTime)
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
                damage.InflictDamage((int)(lightcomboDmg * Mathf.Pow(damageMult, damageExp)));
                time.timeLeft = +0.5f;
                animator.Play("Stagger");
            }
            else if (time.newState == 1)
            {
                damage.InflictDamage(lightguardDmg);
                animator.Play("HitWhGuard");
            }
            else if (player_1.newState == 3 || player_2.newState == 3)
            {
                damage.InflictDamage(slapDmg);
                animator.Play("Stunned");
            }
            else
            {
                damage.InflictDamage((int)(lightguardlessDmg * Mathf.Pow(damageMult, damageExp)));
                time.timeLeft = +0.5f;
                animator.Play("Stagger");
            }
            timeStamp = Time.time;

        }
        else if (other.gameObject.tag == "HeavyFist" && roundEnd.PauseTimer <= leastAountofTime)
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
                damage.InflictDamage((int)(heavycomboDmg * Mathf.Pow(damageMult, damageExp)));
                time.timeLeft = +0.5f;
                animator.Play("Stagger");
            }

            else if (time.newState == 1)
            {
                damage.InflictDamage(heavyguardDmg);
                animator.Play("HitWhGuard");
            }

            else if (player_1.newState == 4 || player_2.newState == 4)
            {
                damage.InflictDamage(chargeDmg);
                animator.Play("Stunned");
            }

            else
            {
                damage.InflictDamage((int)(heavyguardlessDmg * Mathf.Pow(damageMult, damageExp)));
                time.timeLeft = +0.5f;
                animator.Play("Stagger");
            }

            timeStamp = Time.time;

        }
        //if (time.timeLeft <= 0.1f)
        //{
        //    animator.SetInteger("AnimState", 0);
        //}
    }
}