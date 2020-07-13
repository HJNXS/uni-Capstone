using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayClimbAnim : MonoBehaviour {

	public Transform top;
	private GameObject player;

	public bool isMovable = false;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			if (ReInput.players.GetPlayer(0).GetButtonDown("B"))
			{
				player.GetComponent<PlayerController>().enabled = isMovable;
				player.GetComponent<Rigidbody>().isKinematic = !isMovable;
				player.transform.position = top.position;
			}
		}
	}
}
