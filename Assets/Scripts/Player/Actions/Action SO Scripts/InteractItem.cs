using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CollectItem stores the functionality of collecting an item,
/// and destroying the item from the scene and storing it in inventory
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>28/07/18</LastEdited>
[CreateAssetMenu(menuName = "Actions/Interact")]
public class InteractItem : OldAction {

	public override void Execute(GameObject player, GameObject target, bool isAllowed)
	{
		target.GetComponent<ItemDescription>().itemEvent.Invoke(target.GetComponent<ItemDescription>().id);

		if (target.GetComponent<ItemDescription>().disableOnPressed)
		{
			target.GetComponent<ItemDescription>().gameObject.layer = 0;
			target.GetComponent<PopupScript>().IsInteractable = false;
		}
	}
}

