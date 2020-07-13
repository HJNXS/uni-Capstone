/*
* Author: Daniel Newman
* Last Edited: 24/05/18
* Summary: Create a framework from which all game related events
* can be derived from, utilising the observer pattern to manage behaviour.
*/
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>21/09/18</LastEdited>
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(menuName = "Game Events/Create Game Event")]
public class GameEvent : ScriptableObject
{

	//List of listeners that will be notified if the event is raised
	private readonly List<GameEventListener> eventListeners = new List<GameEventListener>();

	private void OnEnable()
	{
		IsDisable = false;
	}

	public bool IsDisable { get; set; }

	public void Invoke(int id = -1)
	{
		if (!IsDisable)
		{
			for (int i = eventListeners.Count - 1; i >= 0; i--)
				eventListeners[i].OnEventRaised(id);
		}
	}

	public void Invoke()
	{
		if (!IsDisable)
		{
			for (int i = eventListeners.Count - 1; i >= 0; i--)
				eventListeners[i].OnEventRaised(-1);
		}
	}

	public void RegisterListener(GameEventListener listener)
	{
		if (!eventListeners.Contains(listener))
			eventListeners.Add(listener);
	}

	public void UnregisterListener(GameEventListener listener)
	{
		if (eventListeners.Contains(listener))
			eventListeners.Remove(listener);
	}

}
