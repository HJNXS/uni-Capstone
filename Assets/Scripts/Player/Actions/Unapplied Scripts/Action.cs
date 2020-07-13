using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OldAction : ScriptableObject 
{
    //public abstract PlayerActions GetName();
    public abstract void Execute(GameObject player, GameObject target, bool isAllowed);
}

