/*
* Author: Daniel Newman
* Last Edited: 01/10/18
* Summary: Listener that provides a unity based event response based on
* a game event invocation
*/

using UnityEngine;
using UnityEngine.Events;

/// <SecondaryContributor>Dinys Monvoisin</SecondaryContributor>
/// <LastEdited>01/10/18</LastEdited>
public class GameEventListener : MonoBehaviour
{
	[Tooltip("Event to register with")]
	public GameEvent Event;

	[Tooltip("Object Id")]
	public int ID = -1;

	[Tooltip("The intended response to invoke when event occurs")]
	public UnityEvent Response;

	private void OnEnable()
	{
		Event.RegisterListener(this);
	}
	private void OnDisable()
	{
		Event.UnregisterListener(this);
	}

	public void OnEventRaised(int id = -1)
	{
		if (id == -1 || ID == id)
			Response.Invoke();
	}
}
