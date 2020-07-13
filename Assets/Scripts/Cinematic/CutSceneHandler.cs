using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneHandler : MonoBehaviour {

	public GameEvent gameEvent;

	private void OnEnable()
	{
		gameEvent.Invoke();
		gameObject.SetActive(false);
	}
}
