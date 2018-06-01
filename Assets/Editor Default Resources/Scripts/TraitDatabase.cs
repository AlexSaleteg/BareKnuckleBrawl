using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TraitDatabase", menuName = "TraitDatabase", order = 1)]
public class TraitDatabase : ScriptableObject {

    public TraitArchetype[] presets;

    public TraitArchetype GetPreset(int index)
    {
        return presets[index];
    }

    public int RandomPresetIndex()
    {
        return Random.Range(0, presets.Length);
    }
}
