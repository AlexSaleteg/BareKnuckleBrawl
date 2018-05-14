using System.Collections;
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
    public bool isConsole1;
    public bool isConsole2;
    public bool isKeyboard;
    public float timeLeft = 0.0f;
    public float chargeTimer = 0.0f;
    float leastAmount = 0.001f;
    public int newState = 0;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animationhinder = GameObject.Find("RoundTimer").GetComponent<TimerScript>();
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (isKeyboard)
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
                }
                else if (Input.GetKeyDown(heavyAttack))
                {
                    animator.SetInteger("AnimState", 10);
                    timeLeft = +1.0f;
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
               else if(Input.GetAxis("L2_1") >= 0.9)
                {
                    animator.Play("SlappyBoi");
                } 
            }
            else if (Input.GetAxis("L2_1") > 0.9 && Input.GetAxis("R2_1") > 0.9)
            {
                animator.SetInteger("AnimState", 1);

                if (Input.GetAxis("Vertical") < -0.9)
                {
                    animator.SetInteger("AnimState", 3);
                }
                else if(Input.GetAxis("Vertical")>  0.9)
                {
                    animator.Play("LPunchBoxer");
                }

                if (Input.GetAxis("RightJoystickVertical") < -0.9)
                {
                    animator.SetInteger("AnimState", 4);
                }
                if(Input.GetAxis("RightJoystickVertical") > 0.9)
                {
                    animator.Play("RPunchBoxer");
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
                else if (Input.GetAxis("L2_1") >= 0.9)
                {
                    animator.Play("SlappyBoi");
                }
            }
            else if (Input.GetAxis("L2_2") > 0.9 && Input.GetAxis("R2_2") > 0.9)
            {
                animator.SetInteger("AnimState", 1);

                if (Input.GetAxis("Vertical2") < -0.9)
                {
                    animator.SetInteger("AnimState", 3);
                }
                else if (Input.GetAxis("Vertical2") > 0.9)
                {
                    animator.Play("LPunchBoxer");
                }

                if (Input.GetAxis("RightJoystickVertical2") < -0.9)
                {
                    animator.SetInteger("AnimState", 4);
                }
                if (Input.GetAxis("RightJoystickVertical2") > 0.9)
                {
                    animator.Play("RPunchBoxer");
                }
            }
            else if (timeLeft <= 0.1f)
            {
                animator.SetInteger("AnimState", 0);
            }
        }
        
        Debug.Log(Input.GetAxis("Vertical2"));
    }
}