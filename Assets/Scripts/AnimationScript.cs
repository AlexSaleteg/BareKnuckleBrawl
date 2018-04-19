using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

    public string lightAttack;
    public string heavyAttack;
    public string dodge;

    private float timeLeft = 0.0f;
    private Animator animator;


	void Start () {
        animator = GetComponent<Animator>();
    }
	
	void Update () {
        timeLeft -= Time.deltaTime;
        if(Input.GetKeyDown(lightAttack)&timeLeft <= 0.001f)
        {
            timeLeft = +0.95f;
            animator.Play("LPunchBoxer");
        }
        if (Input.GetKeyDown(heavyAttack) & timeLeft <= 0.001f)
        {
            timeLeft = +0.95f;
            animator.Play("HPunchBoxer");
        }
        else if (Input.GetKeyDown(dodge) & timeLeft <= 0.001f)
        {
            timeLeft = +0.95f;
            animator.Play("DodgeBoxer");
        }

        if (timeLeft < 0)
        {
            animator.Play("Idle boxer");
        }
    }
}
