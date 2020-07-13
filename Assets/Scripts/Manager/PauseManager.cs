using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

	public delegate void OnGamePause();

	public static event OnGamePause onGamePause;

	public delegate void OnGameResume();

	public static event OnGameResume onGameResume;

	public void RaiseOnGamePause()
	{
		if (onGamePause != null)
		{
			onGamePause();
		}
	}

	public void RaiseOnGameResume()
	{
		if (onGameResume != null)
		{
			onGameResume();
		}
	}
}
