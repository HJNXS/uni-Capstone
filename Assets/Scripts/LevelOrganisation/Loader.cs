using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

	public GameObject inputManager;

	private void Awake()
	{
		if (InputManager.instance == null)
			Instantiate(inputManager);
	}
}
