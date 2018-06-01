using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TraitArchetype", menuName = "Trait Archetype", order = 1)]
public class TraitArchetype : ScriptableObject {

    public string playerName;
    public string flavorText;

    public float lightDmgDfns;
    public float lightDmgAttk;
    public float heavyDmgDfns;
    public float heavyDmgAttk;
    public float chargeDmgDfns;
    public float chargeDmgAttk;
    public float guard;


}
