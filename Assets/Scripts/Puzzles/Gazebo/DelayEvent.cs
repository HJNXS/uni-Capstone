using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayEvent : MonoBehaviour {

	public float delayTime;
	public GameEvent gameEvent;

	public void CallEvent()
	{
		StartCoroutine(Delay());
	}
	
	IEnumerator Delay()
	{
		yield return new WaitForSeconds(delayTime);
		gameEvent.Invoke();
	}

}
