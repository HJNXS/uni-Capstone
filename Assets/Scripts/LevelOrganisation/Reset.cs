using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JMiles42.ItemSystem;

public class Reset : MonoBehaviour {

	public Inventory inventory;
	public Text score;
	private void Start()
	{
		score.text = inventory.totalScore.ToString();
		inventory.ClearInventory();
		inventory.totalScore = 0;
	}
}
