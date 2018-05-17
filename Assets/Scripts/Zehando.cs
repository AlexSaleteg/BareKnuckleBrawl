using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zehando : MonoBehaviour
{

    private float timeLeft;
    public string player;
    private Animator animator;
    private AnimationScript1 state;
    private

    // Use this for initialization
    void Start()
    {
        player = transform.root.name;
        animator = GetComponent<Animator>();
        state = GameObject.Find(player).GetComponent<AnimationScript1>();

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (state.newState == 3)
        {
            animator.enabled = true;
            timeLeft = 0.4f;
        }
        else if (timeLeft < 0.1)
        {
            animator.enabled = false;
        }
    }
}
