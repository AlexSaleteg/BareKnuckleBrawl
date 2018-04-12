using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour {

    public Slider bar;
    public AudioClip hitSound;

    private AudioSource audiosource;
    private int health;
	void Start () {
        audiosource = GameObject.Find("Sound Manager").GetComponent<AudioSource>();
        health = 10;
        bar.value = health;
	}
	
	public void InflictDamage(int damage)
    {
        health -= damage;
        bar.value = health;
        audiosource.PlayOneShot(hitSound, 0.7f);
    }
}
