using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollision : MonoBehaviour {

    public string player;

    private TakeDamage damage;
    void Start()
    {
        damage = GameObject.Find(player).GetComponent<TakeDamage>();
    }

   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LightFist")
        {
            damage.InflictDamage(10);
        }
        else if (other.gameObject.tag == "HeavyFist")
        {
            damage.InflictDamage(20);
        }
    }
}
