using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountButtonPress : MonoBehaviour {

	public GameEvent cellBreakingEvent;
	public GameEvent cellBrokenEvent;
	private int count = 0;

	public void IncreaseCount()
	{
		count++;
		callEvent();
	}

	private void callEvent()
	{
		if ( count == 1)
			cellBreakingEvent.Invoke();

		if ( count == 3)
			cellBrokenEvent.Invoke();
	}
}
