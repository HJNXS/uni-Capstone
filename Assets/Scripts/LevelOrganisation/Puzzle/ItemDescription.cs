using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JMiles42.ItemSystem;

/// <summary>
/// ItemDescription handles information(item type, event) about the object the script is attached to.
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>28/07/18</LastEdited>
public class ItemDescription : MonoBehaviour {

    public Item itemType;

	public GameEvent itemEvent;

	public bool disableOnPressed = false;

	public int id = -1;
}
