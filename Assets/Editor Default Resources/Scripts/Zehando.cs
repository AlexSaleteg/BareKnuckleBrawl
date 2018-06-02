using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zehando : MonoBehaviour
{

    public float timeLeft;
    public string player;
    private Animator animator;
    private Renderer ren;
    private AnimationScript1 state;
    private HeadCollision hit;
    private

    // Use this for initialization
    void Start()
    {
        player = transform.root.name;
        animator = GetComponent<Animator>();
        state = GameObject.Find(player).GetComponent<AnimationScript1>();
        hit = GameObject.Find(player).GetComponent<HeadCollision>();

    }

    // Update is called once per frame
    void Update()
    {
        if(hit.effectsTimer < 0.2)
        {
            ren.enabled = true;
        }
        
    }
}
