using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TraitArchetype", menuName = "Trait Archetype", order = 1)]
public class TraitArchetype : ScriptableObject {

    public string playerName;
    public string flavorText;

    public int lightcomboDmg;
    public int lightguardlessDmg;
    public int lightguardDmg;
    public int slapDmg;
    public int heavycomboDmg;
    public int heavyguardlessDmg;
    public int heavyguardDmg;
    public int chargeDmg;
}
