using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlaceLadder : MonoBehaviour {

	public GameEvent placeLadder;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (ReInput.players.GetPlayer(0).GetButtonDown("A"))
			{
				gameObject.GetComponent<PopupScript>().IsInteractable = false;
				placeLadder.Invoke();
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			if (ReInput.players.GetPlayer(0).GetButtonDown("A"))
			{
				gameObject.GetComponent<PopupScript>().IsInteractable = false;
				placeLadder.Invoke();
			}
		}
	}
}
