using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class StoryPopUp : MonoBehaviour {

	private GameObject player;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	// Update is called once per frame
	void Update () {
		if (ReInput.players.GetPlayer(0).GetButtonDown("A"))
		{
			Destroy(gameObject);
		}
		if (ReInput.players.GetPlayer(0).GetButtonDown("B"))
		{
			transform.parent.gameObject.layer = LayerMask.NameToLayer("Interactable");
			transform.gameObject.SetActive(false);
		}
	}
}
