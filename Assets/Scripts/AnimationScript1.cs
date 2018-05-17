﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript1 : MonoBehaviour
{
    private TimerScript animationhinder;
    public string Lfeint;
    public string Rfeint;
    public string lightAttack;
    public string heavyAttack;
    public string Defensive;
    public string dodge;
    public string player;
    public GameObject slapIndicator;
    public bool isConsole1;
    public bool isConsole2;
    public bool isKeyboard;
    public bool isTestKeyboard;
    public float timeLeft = 0.0f;
    public float chargeTimer = 0.0f;
    public float slapIndicatorTimer = 0.0f;
    float leastAmount = 0.001f;
    public int newState = 0;
    private Animator animator;
    private MicrophoneInput mic;

    void Start()
    {
        player = transform.root.name;
        animator = GetComponent<Animator>();
        animationhinder = GameObject.Find("RoundTimer").GetComponent<TimerScript>();
        mic = GameObject.Find(player).GetComponent<MicrophoneInput>();
    }
    void Update()
    {
        slapIndicatorTimer -= Time.deltaTime;
        timeLeft -= Time.deltaTime;
        if (isTestKeyboard)
        {
            if (Input.GetKey(lightAttack) && Input.GetKey(heavyAttack))
            {
                animator.SetInteger("AnimState", 1);
                newState = 1;
                timeLeft = 1f;
            }
            if (Input.GetKey(lightAttack) && Input.GetKey(heavyAttack) && Input.GetKey(dodge))
            {
                animator.SetInteger("AnimState", 2);
                chargeTimer += Time.deltaTime;
                newState = 2;
            }
            else if (Input.GetKeyUp(dodge) && Input.GetKey(lightAttack) && Input.GetKey(heavyAttack))
            {
                animator.SetInteger("AnimState", 1);
                newState = 1;
                timeLeft = 1f;
            }
            if (Input.GetKeyUp(lightAttack) && newState == 2)
            {
                animator.SetTrigger("Zehando");
                animator.Play("SlappyBoi");
                newState = 3;
                chargeTimer = 0;
            }
            else if (Input.GetKeyUp(heavyAttack) && newState == 2)
            {
                animator.SetInteger("AnimState", 9);
                timeLeft = +2;
                newState = 4;
                chargeTimer = 0;
            }

            if (Input.GetKeyUp(lightAttack) && newState == 1)
            {
                animator.SetInteger("AnimState", 3);
                slapIndicatorTimer = 0.5f;
                timeLeft = 0.5f;
                newState = 5;
            }
            else if (Input.GetKeyDown(Lfeint) && newState == 5 || Input.GetKeyDown(Lfeint) && newState == 7)
            {
                animator.SetInteger("AnimState", 11);
                timeLeft = 0.5f;
            }
            if (Input.GetKeyUp(heavyAttack) && newState == 1)
            {
                newState = 6;
                slapIndicatorTimer = 0.5f;
                animator.SetInteger("AnimState", 4);
                timeLeft = 0.5f;
            }
            else if (Input.GetKeyDown(Lfeint) && newState == 6 || Input.GetKeyDown(Lfeint) && newState == 7)
            {
                animator.SetInteger("AnimState", 10);
                timeLeft = 0.5f;
            }
            if (timeLeft <= 0.1f)
            {
                animator.SetInteger("AnimState", 0);
                newState = 0;
            }
            if (newState == 7)
            {
                slapIndicator.SetActive(true);
            }
            else
            {
                slapIndicator.SetActive(false);
            }
            //if (Input.GetKeyDown(KeyCode.G))
            //{
            //    print("pufff");
            //}
            //else if (Input.GetKeyDown(KeyCode.D))
            //{
            //    print("pifff");
            //}
            //if (MicrophoneInput.MicLoudness > 0.001f)
            //{
            //  print("mic");
            //animator.SetInteger("AnimState", 3);
            //}
        }
        else if (isKeyboard)
        {

            if (Input.GetKey(Defensive))
            {
                //animator.SetInteger("AnimState", 5);
                animator.SetInteger("AnimState", 1);
                newState = 1;

                if (Input.GetKeyDown(Lfeint))
                {
                    animator.SetInteger("AnimState", 3);
                    timeLeft = +1.0f;
                    newState = 5;
                }
                else if (Input.GetKeyDown(lightAttack))
                {
                    animator.SetInteger("AnimState", 11);
                    timeLeft = +1.0f;
                }
                if (Input.GetKeyDown(Rfeint))
                {
                    animator.SetInteger("AnimState", 4);
                    timeLeft = +1.1f;
                    newState = 6;
                }
                else if (Input.GetKeyDown(heavyAttack))
                {
                    animator.SetInteger("AnimState", 10);
                    timeLeft = +1.0f;
                }
                else if (timeLeft <= 0.1f)
                {
                    animator.SetInteger("AnimState", 0);
                    newState = 0;
                }
            }


            else if (Input.GetKey(dodge) & timeLeft <= leastAmount)
            {
                animator.SetInteger("AnimState", 2);
                chargeTimer += Time.deltaTime;
                newState = 2;
                if (Input.GetKey(lightAttack))
                {
                    //animator.SetInteger("handState", 1);
                    //animator.SetInteger("AnimState", 5);
                    animator.Play("SlappyBoi");
                    //animator.Play("TheHand");
                    timeLeft = +1.1f;
                    newState = 3;
                    chargeTimer = 0;
                }

                if (Input.GetKey(heavyAttack) && chargeTimer >= 1.2)
                {
                    animator.SetInteger("AnimState", 9);
                    timeLeft = +1.1f;
                    newState = 4;
                    chargeTimer = 0;
                }


            }
            else if (timeLeft <= 0.1f)
            {
                animator.SetInteger("AnimState", 0);
                newState = 0;
            }
        }



        else if (isConsole2)
        {
            if (Input.GetAxis("Vertical") < -0.9 && Input.GetAxis("RightJoystickVertical") <= -0.9)
            {
                animator.SetInteger("AnimState", 2);

                if (Input.GetAxis("R2_1") >= 0.9)
                {
                    animator.SetInteger("AnimState", 9);
                }
            }
            else if (Input.GetAxis("L2_1") > 0.9 && Input.GetAxis("R2_1") > 0.9)
            {
                animator.SetInteger("AnimState", 1);

                if (Input.GetAxis("Vertical") >= 0.9)
                {
                    animator.SetInteger("AnimState", 3);
                }
                else if (Input.GetAxis("RightJoystickVertical") >= 0.8)
                {
                    animator.SetInteger("AnimState", 4);
                }
            }
            else if (timeLeft <= 0.1f)
            {
                animator.SetInteger("AnimState", 0);
            }
        }


        else if (isConsole1)
        {
            if (Input.GetAxis("Vertical2") < -0.9 && Input.GetAxis("RightJoystickVertical2") <= -0.9)
            {
                animator.SetInteger("AnimState", 2);

                if (Input.GetAxis("R2_2") >= 0.9)
                {
                    animator.SetInteger("AnimState", 9);
                }
            }
            else if (Input.GetAxis("L2_2") > 0.9 && Input.GetAxis("R2_2") > 0.9)
            {
                animator.SetInteger("AnimState", 1);

                if (Input.GetAxis("Vertical2") >= 0.9)
                {
                    animator.SetInteger("AnimState", 3);
                }
                else if (Input.GetAxis("RightJoystickVertical2") >= 0.8)
                {
                    animator.SetInteger("AnimState", 4);
                }
            }
            else if (timeLeft <= 0.1f)
            {
                animator.SetInteger("AnimState", 0);
            }
        }
    }
}