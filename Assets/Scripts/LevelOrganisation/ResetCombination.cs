using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class ResetCombination : MonoBehaviour {

	private SceneManage sceneManager;
	private Player player;
	private bool isDisable = false;

	private void Start()
	{
		sceneManager = GetComponent<SceneManage>();
		player = ReInput.players.GetPlayer(0);
	}
	// Update is called once per frame
	void Update () {
		if (player.GetButton("Start") && player.GetButton("Back") && !isDisable)
		{
			sceneManager.ResetGame();
			isDisable = true;
		}

		if (player.GetButton("Start") && player.GetButton("LB") && player.GetButton("LT") && !isDisable)
		{
			sceneManager.ResetSceneFade();
			isDisable = true;
		}
	}
}
