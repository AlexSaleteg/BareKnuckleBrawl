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
    public Renderer VFX;
    public GameObject VFx;
    private AnimationScript1 time;
    private TimerScript roundEnd;
    public float effectsTimer;
   // private Animator hit;

    [HideInInspector]
    public float leastAmountofTime;
    void Start()
    {
        
        player = transform.root.name;
        skill = traits.GetPreset(PlayerPrefs.GetInt("Player" + player[6] + "Trait", 0));
        player_1 = GameObject.Find("Player1").GetComponent<AnimationScript1>();
        player_2 = GameObject.Find("Player2").GetComponent<AnimationScript1>();
        time = GameObject.Find(player).GetComponent<AnimationScript1>();
        animator = GameObject.Find(player).GetComponent<Animator>();
         VFX = GameObject.FindGameObjectWithTag("birds").GetComponent<Renderer>();
        VFx = GameObject.Find("Birds");
        damage = GameObject.Find(player).GetComponent<TakeDamage>();
        roundEnd = GameObject.Find("RoundTimer").GetComponent<TimerScript>();
       // hit = GameObject.Find("hit").GetComponent<Animator>();
        leastAmountofTime = 0.001f;
        //VFx.SetActive(false);
    }

    void Update()
    {
        effectsTimer -= Time.deltaTime;
        if (player_2.newState == 2 && time.slapIndicatorTimer > 0)
        {
            player_1.newState = 7;
        }

        if (player_1.newState == 2 && time.slapIndicatorTimer > 0)
        {
            player_2.newState = 7;
        }
        if (effectsTimer > 0.2)
        {
            VFx.SetActive(true);
            // VFX.SetInteger("VFX1", 1);
        }
        else if (effectsTimer <= 0.1)
        {
           // VFX.SetInteger("VFX1", 0);
            //VFx.SetActive(true);
            VFX.enabled = false;
        }
        if (effectsTimer > 0.1)
        {
            VFX.enabled = true;
            //VFx.SetActive(false);
            //effectsTimer = 2f;
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // hit.enabled = true;
        TraitArchetype enemy = traits.GetPreset(PlayerPrefs.GetInt("Player" + other.transform.root.name[6] + "Trait", 0));
            if (other.gameObject.tag == "LightFist" && roundEnd.PauseTimer <= leastAmountofTime)
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
            //if (comboTimer >= 0.1f)
            //{
            //    damage.InflictDamage((int)(skill.lightcomboDmg * Mathf.Pow(damageMult, damageExp)));
            //    comboTimer = +0.5f;
            //    //animator.Play("Stagger");
            //    //animator.Play("HitWhGuard");
            //}
            if (time.newState == 1)
            {
                damage.InflictDamage((int)((enemy.lightDmgAttk * Mathf.Pow(damageMult, damageExp)) / (skill.lightDmgDfns * skill.guard)));
                animator.Play("HitWhGuard");
               
            }
            else if (player_1.newState == 3 && player_2.newState !=0 || player_2.newState == 3 && player_1.newState !=0)
            {
                animator.Play("Stunned");
            }
            if (player_1.newState == 3 && player_2.newState == 0 || player_2.newState == 3 && player_1.newState == 0)
            {

            }
            else if (time.newState == 2)
            {
                damage.InflictDamage((int)((enemy.lightDmgAttk * Mathf.Pow(damageMult, damageExp)) / skill.lightDmgDfns));
                time.timeLeft = +0.5f;

            }
            else if(time.newState == 0)
            {
                damage.InflictDamage((int)((enemy.lightDmgAttk * Mathf.Pow(damageMult, damageExp)) / skill.lightDmgDfns));
                time.timeLeft = +0.5f;
                animator.Play("Stagger");
            }
            else if (player_1.newState == 3 || player_2.newState == 3)
            {

            }
            timeStamp = Time.time;

        }
        else if (other.gameObject.tag == "HeavyFist" && roundEnd.PauseTimer <= leastAmountofTime)
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

            //if (comboTimer >= 0.1f)
            //{
            //    damage.InflictDamage((int)(skill.heavycomboDmg * Mathf.Pow(damageMult, damageExp)));
            //    comboTimer = +0.5f;
            //    //animator.Play("Stagger");
            //    //animator.Play("HitWhGuard");
            //}

            if (player_1.newState == 1 || player_2.newState == 1)
            {
                damage.InflictDamage((int)((enemy.heavyDmgAttk * Mathf.Pow(damageMult, damageExp)) / (skill.heavyDmgDfns * skill.guard)));
                animator.Play("HitWhGuard");
            }

            if (player_1.newState == 9 || player_2.newState == 9)
            {
                damage.InflictDamage((int)(enemy.chargeDmgAttk / skill.chargeDmgDfns));
                animator.Play("Stunned");
                effectsTimer = 2f;
                VFx.SetActive(true);
            }

            else if (time.newState == 2)
            {
                damage.InflictDamage((int)((enemy.heavyDmgAttk * Mathf.Pow(damageMult, damageExp)) / (skill.heavyDmgDfns * skill.guard)));
                time.timeLeft = +0.5f;
               
               
            }

            else if (time.newState == 0)
            {
                damage.InflictDamage((int)((enemy.heavyDmgAttk * Mathf.Pow(damageMult, damageExp)) / skill.heavyDmgDfns));
                time.timeLeft = +0.5f;
                animator.Play("Stagger");

            }
            else
            {
               // VFx.SetActive(false);
            }
            

            timeStamp = Time.time;

        }
        //if (time.timeLeft <= 0.1f)
        //{
        //    animator.SetInteger("AnimState", 0);
        //}
       
    }

    public TraitArchetype GetSkill()
    {
        return skill;
    }
}