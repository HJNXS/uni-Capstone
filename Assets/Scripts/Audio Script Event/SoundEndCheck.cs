using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEndCheck : MonoBehaviour {

	public void ReactiveEvent(GameEvent gameEvent)
	{
		StartCoroutine(CheckSoundFinish(gameEvent));
	}

	IEnumerator CheckSoundFinish(GameEvent gameEvent)
	{
		while(gameObject.GetComponent<AudioSource>().isPlaying)
		{
			yield return null;
		}
		gameEvent.IsDisable = false;
	}
}
