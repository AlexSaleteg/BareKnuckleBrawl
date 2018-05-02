using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private TimerScript animationhinder;
    public string lightAttack;
    public string heavyAttack;
    public string Defensive;
    public string dodge;
    public string player;
    public float timeLeft = 0.0f;
    public float chargeTimer = 0.0f;
    public float leastAmount = 0.001f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animationhinder = GameObject.Find("RoundTimer").GetComponent<TimerScript>();
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (Input.GetKey(Defensive))
        {
            animator.SetInteger("AnimState", 5);
        }
        else if (Input.GetKeyDown(lightAttack) & timeLeft <= leastAmount)
        {
            animator.SetInteger("AnimState", 1);
            timeLeft = +1.0f;
        }
        else if (Input.GetKeyDown(heavyAttack) & timeLeft <= leastAmount)
        {
            animator.SetInteger("AnimState", 2);
            timeLeft = +1.1f;
        }
        else if (Input.GetKey(dodge) & timeLeft <= leastAmount)
        {
            animator.SetInteger("AnimState", 3);
            chargeTimer += Time.deltaTime;
        }
        else if (timeLeft <= 0.1f)
        {
            animator.SetInteger("AnimState", 0);
        }

    //    if (Input.GetAxis("Vertical") <= -1 && Input.GetAxis("RightJoystickVertical") >= 1)
    //    {
    //        //animator.Play("DodgeBoxer");
    //        if (timeLeft <= 0.1)
    //        {
    //            animator.SetInteger("AnimState", 3);
    //            //animator.Play("DodgeStart");
    //            //timeLeft = +1.0f;
    //        }
    //    }

    //    else if (Input.GetAxis("Vertical") >= 1)
    //    {

    //        if (timeLeft <= 0.1)
    //            animator.SetInteger("AnimState", 1);
    //        //animator.Play("LPunchBoxer");

    //        timeLeft = +0.5f;
    //    }
    //    else if (Input.GetAxis("RightJoystickVertical") <= 0)
    //    {
    //        if (timeLeft <= 0.1)
    //            animator.SetInteger("AnimState", 2);
    //        //animator.Play("RPunchBoxer");
    //        timeLeft = +1.1f;
    //    }
    //    else if (timeLeft <= 0.1f)
    //    {
    //        animator.SetInteger("AnimState", 0);
    //    }
    //    Debug.Log(Input.GetAxis("RightJoystickVertical"));
    }
}