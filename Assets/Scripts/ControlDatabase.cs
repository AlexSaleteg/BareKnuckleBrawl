using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ControlDatabase", menuName = "ControlDatabase", order = 1)]
public class ControlDatabase : ScriptableObject {

    public ControlSetup[] controls;

    public ControlSetup GetControls(int index)
    {
        return controls[index];
    }
}
