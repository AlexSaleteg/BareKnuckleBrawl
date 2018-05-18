using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour
{
    public int maxHealthInit;
    public int damageDiff;
    public AudioClip hitSound1;
    public AudioClip hitSound2;
    public AudioClip hitSound3;


    private Slider maxBar;
    private Slider bar;
    private bool cooldown;
    private AudioSource audiosource;
    [HideInInspector]
    private int maxHealth;
    [HideInInspector]
    public int health;
    void Start()
    {
        if (gameObject.name == "Player1")
        {
            maxBar = GameObject.Find("MaxHealthbar1").GetComponent<Slider>();
            bar = GameObject.Find("Healthbar1").GetComponent<Slider>();
        }
        else if (gameObject.name == "Player2")
        {
            maxBar = GameObject.Find("MaxHealthbar2").GetComponent<Slider>();
            bar = GameObject.Find("Healthbar2").GetComponent<Slider>();
        }
        audiosource = GetComponent<AudioSource>();
        maxHealth = PlayerPrefs.GetInt("Player" + gameObject.name[6] + "Health", maxHealthInit);
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
    
