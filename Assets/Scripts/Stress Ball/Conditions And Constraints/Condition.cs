using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Oprator { Less, Greater, Equal }
public class Condition : ScriptableObject
{
    public virtual bool ApplyCondition(ref float radius, ref Color color) { return false; }
}