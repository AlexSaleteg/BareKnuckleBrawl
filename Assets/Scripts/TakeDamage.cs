using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour
{
    public int maxHealth;
    public int damageDiff;
    public Slider maxBar;
    public Slider bar;
    public AudioClip hitSound;

    private bool cooldown;
    private AudioSource audiosource;
    [HideInInspector]
    public int health;
    void Start()
    {
        audiosource = GameObject.Find("Sound Manager").GetComponent<AudioSource>();
        health = maxHealth;
        bar.value = health;
    }
    void FixedUpdate()
    {
        if (health < maxHealth && !cooldown)
        {
            StartCoroutine(Cooldown());
            health++;
            bar.value = health;
        }
    }
    public void InflictDamage(int damage)
    {
        health -= damage;
        maxHealth -= damage / damageDiff;
        bar.value = health;
        maxBar.value = maxHealth;
        audiosource.PlayOneShot(hitSound, 0.7f);
    }

    IEnumerator Cooldown()
    {
        cooldown = true;
        yield return new WaitForSeconds(0.5f);
        cooldown = false;
    }
}
    
