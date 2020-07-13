using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Update the player score when an item is pickup
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>25/08/18</LastEdited>
public class CollectPointObject : MonoBehaviour {

    public GameEvent increaseScore;
    public UpdateScore updateScore;
    
    public void Collect()
    {
        increaseScore.Invoke();
        updateScore.collectedPoints.Remove(this);
        Destroy(gameObject);
    }
}
