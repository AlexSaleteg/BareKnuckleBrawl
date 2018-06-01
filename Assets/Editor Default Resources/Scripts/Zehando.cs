using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zehando : MonoBehaviour
{

    public float timeLeft;
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
        
        if (state.newState == 8)
        {
            animator.enabled = true;
        }
        
        else if(animator.enabled == true)
        {
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft < -0.14)
        {
            timeLeft = 0;
            animator.enabled = false;
        }
    }
}
