using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableResetScene : MonoBehaviour {

	public GameEvent gameEvent;

	private void OnEnable()
	{
		gameEvent.IsDisable = false;		
	}
}
