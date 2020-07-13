using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CollectItem stores the functionality of collecting an item,
/// and destroying the item from the scene and storing it in inventory
/// 
/// NOTE: Need to fix script to use new 'action/states/etc.' scripts. 
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>28/07/18</LastEdited>
[CreateAssetMenu(menuName = "Actions/Collect")]
public class CollectItem : OldAction {
	public override void Execute(GameObject player, GameObject target, bool isAllowed)
	{
		target.GetComponent<PopupScript>().IsInteractable = false;
		target.GetComponent<ItemDescription>().itemEvent.Invoke();
		player.GetComponentInChildren<FindInteractObjCollision>().Remove(target);
		Destroy(target);
	}

}
