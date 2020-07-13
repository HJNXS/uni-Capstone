using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JMiles42.ItemSystem;
using System;

public abstract class PuzzleCheck : ScriptableObject {

    [System.NonSerialized]
    protected bool oneTime = false;

    public abstract bool Check(Inventory invent); // Probably, do not need to be abstract
}
