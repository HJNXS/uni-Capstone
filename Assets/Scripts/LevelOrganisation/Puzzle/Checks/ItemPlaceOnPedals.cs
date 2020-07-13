using System.Collections;
using System.Collections.Generic;
using JMiles42.ItemSystem;
using UnityEngine;

/// Need changes see with hax.
/// <summary>
/// Check whether the all stand has an item placed on the place holder.
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>26/08/18</LastEdited>
public class ItemPlaceOnPedals : MonoBehaviour {

	public List<PlaceItem> pedals;

	public GameEvent cyanPlaced;

	private bool oneTime = false;

	private void Update()
	{
		if (Check() && !oneTime)
		{
			oneTime = true;
			cyanPlaced.Invoke();
		}
	}

	public bool Check()
	{
        //return pedals.TrueForAll(ItemPlacedOnStand);
        return false;
	}

	/// <summary>
	/// Predicate to search if an item is place on stand.
	/// </summary>
	/// <param name="placeItem"></param>
	/// <returns></returns>
	private static bool ItemPlacedOnStand(PlaceItem placeItem)
	{
        //return placeItem.IsItemPlaced;
        return false;
	}

}
