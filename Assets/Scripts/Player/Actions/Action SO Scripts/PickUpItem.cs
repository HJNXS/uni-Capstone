using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

/// <summary>
/// Handles player pickup
/// </summary>
/// <PrimaryContributor>Hayley Kumpis</PrimaryContributor>
/// <SecondContributor>Dinys Monvoisin</SecondContributor>
/// <LastEdited>25/08/18</LastEdited>
[CreateAssetMenu(menuName = "Actions/Pick Up")]
public class PickUpItem : OldAction
{
	public GameObject pbRoot;

	[System.NonSerialized]
	public bool isItemPickUp = false;

	[System.NonSerialized]
	public bool oneTime = false;

    public override void Execute(GameObject player, GameObject target, bool isAllowed)
    {
		CapsuleCollider capsuleCollider = target.GetComponent<CapsuleCollider>();
		Rigidbody rb = target.GetComponent<Rigidbody>();

		if (isAllowed)
		{
			//pick-up
			if (target.GetComponent<PopupScript>().IsInteractable)
			{
				// Set object position relative to player
				target.GetComponent<PopupScript>().IsInteractable = false;
				player.GetComponentInChildren<FindInteractObjCollision>().Clear();
				target.transform.position = GameObject.FindGameObjectWithTag("PickUpPin").transform.position;
				target.transform.parent = GameObject.FindGameObjectWithTag("PickUpPin").transform;
				capsuleCollider.enabled = false;
				rb.useGravity = false;
				return;
			}
			else
				target.GetComponent<PopupScript>().IsInteractable = true;
			capsuleCollider.enabled = true;
			target.transform.parent = null;
			rb.useGravity = true;
		}

	}

	[System.Obsolete("No longer using through into the game")]
	public void AddParabola(GameObject target, GameObject player)
	{
		var pC = target.gameObject.AddComponent<parabolaController>();
        if(pbRoot == null)
        {
            pbRoot = Resources.Load<GameObject>("PbRoot");
        }
        pC.ParabolaRoot = Instantiate(
            pbRoot, 
            target.transform.position,
            target.transform.rotation,//Quaternion.identity, 
            target.transform);
        //pC.ParabolaRoot.transform.localScale = new Vector3(1, 1, 1);
        
    }
}
