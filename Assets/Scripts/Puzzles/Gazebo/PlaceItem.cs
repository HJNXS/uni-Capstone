using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

/// <summary>
/// Handles items being placed on the stand when the player is nearby.
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>26/08/18</LastEdited>
public class PlaceItem : MonoBehaviour {

	public Transform placeHolder;
	public Transform parentPickUpObj;

	public GameEvent unlockCellEvent;

	public bool IsItemPlaced { get; private set; }

	public int id = 0;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.transform.GetComponent<InputHandler>().IsAllowed = false;
			Place();
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			other.transform.GetComponent<InputHandler>().IsAllowed = false;
			Place();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			other.transform.GetComponent<InputHandler>().IsAllowed = true;
		}
	}

	void Place()
	{
		if (parentPickUpObj.childCount != 0)
		{
		Transform item = parentPickUpObj.GetChild(0).transform;
		ItemDescription description = item.GetComponent<ItemDescription>();
			if (description.id == id)
			{
				if (ReInput.players.GetPlayer(0).GetButtonSinglePressDown("A"))
				{
					if (item != null)
					{
						if (item.GetComponent<ItemDescription>().id == id)
						{
							item.position = placeHolder.position;
							item.parent = placeHolder;
							item.GetComponent<Rigidbody>().useGravity = false;
						}
					}
					IsItemPlaced = (placeHolder.childCount != 0);
					if (IsItemPlaced)
					{
						//play pedestal moving down animation
						transform.GetComponent<Animator>().enabled = true;
						unlockCellEvent.Invoke();				
					}
				}
			}
		} 
	}
}
