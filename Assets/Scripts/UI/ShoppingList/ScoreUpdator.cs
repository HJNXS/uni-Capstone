using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JMiles42.ItemSystem;
using UnityEngine.SceneManagement;

public class ScoreUpdator : MonoBehaviour {

	public Text txt;

	public Inventory inventory;

	// Update is called once per frame
	void Update () {
		txt.text = inventory.totalScore.ToString(); //need to use the event for that so that only when inventory updates this script is called	
		PlayerPrefs.SetInt("Profit", inventory.totalScore);
	}
}
