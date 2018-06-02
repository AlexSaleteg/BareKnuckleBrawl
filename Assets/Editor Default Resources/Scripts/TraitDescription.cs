using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraitDescription : MonoBehaviour {

    public Text traitname;
    public Text description;
    public int player;
    public TraitDatabase database;

    private TraitArchetype archetype;
    void Start ()
    {
        archetype = database.GetPreset(PlayerPrefs.GetInt("Player" + player + "Trait", 0));
        traitname.text = archetype.playerName;
        description.text = archetype.flavorText;
        StartCoroutine(Timer());
	}
	
	IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
