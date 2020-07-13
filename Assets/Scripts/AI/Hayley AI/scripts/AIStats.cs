using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AI statistics. Applied as a scriptable.
/// </summary>
///<PrimaryContributor>Hayley Kumpis</PrimaryContributor>
/// <LastEdited>07/09/2018</LastEdited>
/// 
[CreateAssetMenu (menuName = "PlugAi/AIStats")]
public class AIStats : ScriptableObject {

    public float moveSpeed = 3f;
    public float chaseSpeed = 5f;
    public float addOnchaseSpeed = 0.2f;
    public float resetChaseSpeed = 3.5f;
    //public float lookRange = 40f;
    public float lookSphereCastRadius = 2f;
    //public float searchingTurnSpeed = 2f;
    public float searchDuration = 7f;
    public float catchDistance = 0.5f;
    public float catchTime = 0.5f;

}
