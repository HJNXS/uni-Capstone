using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for handling AI transitions between states.
/// </summary>
/// <PrimaryContributor>Hayley Kumpis</PrimaryContributor>
/// <LastEdited>11/09/2018</LastEdited>
/// <remarks>Used as a scriptable</remarks>
[System.Serializable]
public class Transition {

    public Decision decision;
    public State trueState;
    public State falseState;
	
}
