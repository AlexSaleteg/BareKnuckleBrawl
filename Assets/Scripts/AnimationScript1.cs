using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript1 : MonoBehaviour
{
    
    public string Lfeint;
    public string Rfeint;
    public string lightAttack;
    public string heavyAttack;
    public string Defensive;
    public string dodge;
    public ControlDatabase controlDatabase;
    public GameObject slapIndicator;
    public bool isConsole1;
    public bool isConsole2;
    public bool isKeyboard;
    public bool isTestKeyboard;
    public float timeLeft = 0.0f;
    public float chargeTimer = 0.0f;
    public float slapIndicatorTimer = 0.0f;
    public int newState = 0;

    private ControlSetup controls;
    private string player;
    private TimerScript animationhinder;
    private float leastAmount = 0.001f;
    private Animator animator;
    private MicrophoneInput mic;
    private AudioSource audiosource;
    private AudioClip slapSound;
    private Animator hit;


    void Start()
    {
        audiosource = GameObject.Find("Sound Manager").GetComponents<AudioSource>()[1];
        player = gameObject.name;
        controls = controlDatabase.GetControls(gameObject.name[6] - 49);
        Lfeint = controls.Lfeint;
        Rfeint = controls.Rfeint;
        lightAttack = controls.lightAttack;
        heavyAttack = controls.heavyAttack;
        Defensive = controls.Defensive;
        dodge = controls.dodge;
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
            if (Input.GetKey(controls.lightAttack) && Input.GetKey(controls.heavyAttack))
            {
                animator.SetInteger("AnimState", 1);
                newState = 1;
                timeLeft = 1f;
            }
            if (Input.GetKey(controls.lightAttack) && Input.GetKey(controls.heavyAttack) && Input.GetKey(controls.dodge))
            {
                animator.SetInteger("AnimState", 2);
                chargeTimer += Time.deltaTime;
                newState = 2;
                timeLeft = 1f;
            }
            else if (Input.GetKeyUp(controls.dodge) && Input.GetKey(controls.lightAttack) && Input.GetKey(controls.heavyAttack))
            {
                animator.SetInteger("AnimState", 1);
                newState = 1;
                timeLeft = 1f;
            }
            if (Input.GetKeyUp(controls.lightAttack) && newState == 2)
            {
                //animator.SetTrigger("Zehando");
                
                newState = 3;
                
            }
            else if (Input.GetKeyDown(controls.Lfeint) && newState == 3 || MicrophoneInput.MicLoudness > 0.01 && newState == 3)
            {
                newState = 8;
                animator.Play("SlappyBoi");
                audiosource.PlayOneShot(slapSound);
                newState = 3;
                chargeTimer = 0;
            }
            if (Input.GetKeyUp(controls.heavyAttack) && newState == 2)
            {
                
                timeLeft = +2;
                newState = 4;
               
            }
            else if(Input.GetKeyDown(controls.Lfeint) && newState == 4 || MicrophoneInput.MicLoudness > 0.01 && newState == 4)
            {
                newState = 9;
                animator.SetInteger("AnimState", 9);
                chargeTimer = 0;
            }

            if (Input.GetKeyUp(controls.lightAttack) && newState == 1 || MicrophoneInput.MicLoudness > 0.01 && newState == 1)
            {
                animator.SetInteger("AnimState", 3);
                slapIndicatorTimer = 0.5f;
                timeLeft = 0.5f;
                newState = 5;
            }
            else if (Input.GetKeyDown(controls.Lfeint) && newState == 5 || Input.GetKeyDown(controls.Lfeint) && newState == 7)
            {
                animator.SetInteger("AnimState", 11);
                timeLeft = 0.5f;
            }
            if (Input.GetKeyUp(controls.heavyAttack) && newState == 1 || MicrophoneInput.MicLoudness > 0.01 && newState == 1)
            {
                newState = 6;
                slapIndicatorTimer = 0.5f;
                animator.SetInteger("AnimState", 4);
                timeLeft = 0.5f;
            }
            else if (Input.GetKeyDown(controls.Lfeint) && newState == 6 || Input.GetKeyDown(controls.Lfeint) && newState == 7)
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
            
        }
        else if (isKeyboard)
        {

            if (Input.GetKey(controls.Defensive))
            {
                //animator.SetInteger("AnimState", 5);
                animator.SetInteger("AnimState", 1);
                newState = 1;

                if (Input.GetKeyDown(controls.Lfeint))
                {
                    animator.SetInteger("AnimState", 3);
                    timeLeft = +1.0f;
                    newState = 5;
                }
                else if (Input.GetKeyDown(controls.lightAttack))
                {
                    animator.SetInteger("AnimState", 11);
                    timeLeft = +1.0f;
                }
                if (Input.GetKeyDown(controls.Rfeint))
                {
                    animator.SetInteger("AnimState", 4);
                    timeLeft = +1.1f;
                    newState = 6;
                }
                else if (Input.GetKeyDown(controls.heavyAttack))
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


            else if (Input.GetKey(controls.dodge) & timeLeft <= leastAmount)
            {
                animator.SetInteger("AnimState", 2);
                chargeTimer += Time.deltaTime;
                newState = 2;
                if (Input.GetKey(controls.lightAttack))
                {
                    //animator.SetInteger("handState", 1);
                    //animator.SetInteger("AnimState", 5);
                    animator.Play("SlappyBoi");
                    //animator.Play("TheHand");
                    timeLeft = +1.1f;
                    newState = 3;
                    chargeTimer = 0;
                }

                if (Input.GetKey(controls.heavyAttack) && chargeTimer >= 1.2)
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