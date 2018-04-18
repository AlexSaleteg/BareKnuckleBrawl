using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

    public string attack;
    public string dodge;
    public string leanBack;

    private float timeLeft = 0.0f;
    private Animator animator;


	void Start () {
        animator = GetComponent<Animator>();
    }
	
	void Update () {
        timeLeft -= Time.deltaTime;
        if(Input.GetKeyDown(attack)&timeLeft <= 0.001f)
        {
            timeLeft = +0.95f;
            animator.Play("LPunchBoxer");
        }
        else if (Input.GetKeyDown(dodge) & timeLeft <= 0.001f)
        {
            timeLeft = +0.95f;
            animator.Play("DodgeBoxer");
        }
        else if (Input.GetKey(leanBack))
        {

        }

        if (timeLeft < 0)
        {
            animator.Play("Idle boxer");
        }
    }
}
