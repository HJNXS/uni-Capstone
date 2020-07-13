using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoInFountain : MonoBehaviour {

	public Transform player;
	public Transform positionSet;

	public void moveToPosition()
	{
		player.position = positionSet.position;
	}
}
