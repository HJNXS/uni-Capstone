using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to handle the conditions to change between states. 
/// </summary>
/// <PrimaryContributor>Hayley Kumpis</PrimaryContributor>
/// <LastEdited>11/09/2018</LastEdited>
/// <remarks>Overwritten by other, specific scripts. Implemented via scriptables.</remarks>

public abstract class Decision : ScriptableObject {

    public abstract bool Decide(StateController controller);
}
