using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {
    private TimerScript animationhinder;
    public string lightAttack;
    public string heavyAttack;
    public string Defensive;
    public string dodge;
<<<<<<< Updated upstream

    private float timeLeft = 0.0f;
=======
    public string player;
    public float timeLeft = 0.0f;
>>>>>>> Stashed changes
    private Animator animator;
	void Start () {
        animator = GetComponent<Animator>();
        animationhinder = GameObject.Find("RoundTimer").GetComponent<TimerScript>();
    }
    void Update() {
        timeLeft -= Time.deltaTime;
        if (Input.GetKeyDown(Defensive))
        {
            animator.Play("Idle boxer");
        }
        else if (Input.GetKeyDown(lightAttack) & timeLeft <= 0.001)
        {
            animator.Play("LPunchBoxer");
        }
        else if (Input.GetKeyDown(heavyAttack) & timeLeft <= 0.001& animationhinder.player2Wins >= 0 & animationhinder.player1Wins >= 0 )
        {
            animator.Play("RPunchBoxer");
        }
        else if (Input.GetKeyDown(dodge) & timeLeft<=0.001 & animationhinder.player2Wins >= 0 & animationhinder.player1Wins >= 0)
        {
            timeLeft = +1.5f;
            animator.Play("DodgeStart");
        }
<<<<<<< Updated upstream

        if (timeLeft < 0)
=======
        if (Input.GetKeyUp(lightAttack))
        {
            animator.SetBool("LPunchBoxer", false);
        }
        else if (Input.GetKeyUp(heavyAttack))
>>>>>>> Stashed changes
        {
            animator.SetBool("RPunchBoxer", false);
        }
        else if (Input.GetKeyUp(dodge))
        {
            animator.SetBool("DodgeStart", false);
        }
        else if (timeLeft <= 0.001f)
        {
            animator.SetBool("Stagger", false);
        }
    }
}
