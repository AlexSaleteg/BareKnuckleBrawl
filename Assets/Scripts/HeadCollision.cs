using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollision : MonoBehaviour
{
    public TraitDatabase traits;

    private TraitArchetype skill;
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


    [HideInInspector]
    public float leastAountofTime;
    void Start()
    {
        player = transform.root.name;
        skill = traits.GetPreset(PlayerPrefs.GetInt("Player" + player[6] + "Trait", 0));
        player_1 = GameObject.Find("Player1").GetComponent<AnimationScript1>();
        player_2 = GameObject.Find("Player2").GetComponent<AnimationScript1>();
        time = GameObject.Find(player).GetComponent<AnimationScript1>();
        animator = GameObject.Find(player).GetComponent<Animator>();
        damage = GameObject.Find(player).GetComponent<TakeDamage>();
        roundEnd = GameObject.Find("RoundTimer").GetComponent<TimerScript>();
        leastAountofTime = 0.001f;

    }

    void Update()
    {
        comboTimer -= Time.deltaTime;
        if (player_2.newState == 2 && time.slapIndicatorTimer > 0)
        {
            player_1.newState = 7;
        }
        {
        else if (player_1.newState == 2 && time.slapIndicatorTimer > 0)
            player_2.newState = 7;
        }
    }


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
            if (comboTimer >= 0.1f)
            {
                damage.InflictDamage((int)(skill.lightcomboDmg * Mathf.Pow(damageMult, damageExp)));
                time.timeLeft = +0.5f;
                //animator.Play("Stagger");
                //animator.Play("HitWhGuard");
            }
            else if (time.newState == 1)
            {
                damage.InflictDamage(skill.lightguardDmg);
                animator.Play("HitWhGuard");
            }
            else if (player_1.newState == 3 || player_2.newState == 3)
            {
                damage.InflictDamage(skill.slapDmg);
                animator.Play("Stunned");
            }
            else if (time.newState == 2)
            {
                damage.InflictDamage((int)(lightguardlessDmg * Mathf.Pow(damageMult, damageExp)));
                time.timeLeft = +0.5f;
            }
            else
            {
                damage.InflictDamage((int)(skill.lightguardlessDmg * Mathf.Pow(damageMult, damageExp)));
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

            if (comboTimer >= 0.1f)
            {
                damage.InflictDamage((int)(skill.heavycomboDmg * Mathf.Pow(damageMult, damageExp)));
                time.timeLeft = +0.5f;
                //animator.Play("Stagger");
                //animator.Play("HitWhGuard");
            }

            else if (time.newState == 1)
            {
                damage.InflictDamage(skill.heavyguardDmg);
                animator.Play("HitWhGuard");
            }

            else if (player_1.newState == 4 || player_2.newState == 4)
            {
                damage.InflictDamage(skill.chargeDmg);
                animator.Play("Stunned");
            }

            else if (time.newState == 2)
            {
                damage.InflictDamage((int)(lightguardlessDmg * Mathf.Pow(damageMult, damageExp)));
                time.timeLeft = +0.5f;
            }

            else
            {
                damage.InflictDamage((int)(skill.heavyguardlessDmg * Mathf.Pow(damageMult, damageExp)));
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