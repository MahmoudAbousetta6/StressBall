using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condation : ScriptableObject
{
    public virtual bool ApplyCondation(ref float radius, ref Color color) { return false; }
}