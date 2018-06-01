using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ControlScheme", menuName = "Control Scheme", order = 1)]
public class ControlSetup : ScriptableObject {

    public string Lfeint;
    public string Rfeint;
    public string lightAttack;
    public string heavyAttack;
    public string Defensive;
    public string dodge;
}
