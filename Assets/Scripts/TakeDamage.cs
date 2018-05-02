using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour
{
    public int maxHealthInit;
    public int damageDiff;
    public Slider maxBar;
    public Slider bar;
    public AudioClip hitSound1;
    public AudioClip hitSound2;
    public AudioClip hitSound3;


    private bool cooldown;
    private AudioSource audiosource;
    [HideInInspector]
    public int maxHealth;
    [HideInInspector]
    public int health;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        maxHealth = 100 /*PlayerPrefs.GetInt(gameObject.name + "Health", maxHealthInit)*/;
        maxBar.value = maxHealth;
        health = maxHealth;
        bar.value = health;
    }
    void FixedUpdate()
    {
        if (health < maxHealth && !cooldown && health != 0)
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
        PlayerPrefs.SetInt(gameObject.name + "Health", maxHealth);
        bar.value = health;
        maxBar.value = maxHealth;
        int randNum = Random.Range(0, 3);
        if (randNum == 0)
        {
            audiosource.PlayOneShot(hitSound1, 0.7f);
        }
        else if (randNum == 1)
        {
            audiosource.PlayOneShot(hitSound2, 0.7f);
        }
        else
        {
            audiosource.PlayOneShot(hitSound3, 0.7f);
        }
        audiosource.pitch = Random.Range(0.8f, 1.2f);
    }

    IEnumerator Cooldown()
    {
        cooldown = true;
        yield return new WaitForSeconds(0.5f);
        cooldown = false;
    }
}
    
