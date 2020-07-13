using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles turning off a light when player interact with it and
/// the turning ON after a period of time
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>02/09/18</LastEdited>
public class LightDown : MonoBehaviour {

	public delegate void OnLightOff(Transform t);

	public static event OnLightOff onLightOff;

	public delegate void OnLightOn(Transform t);

	public static event OnLightOff onLightOn;

	public bool IsLightOn { get; private set; }

	private void Start()
	{
		IsLightOn = true;	
	}

	public void RaiseOnLightOff()
	{
		if (onLightOff != null)
		{
			onLightOff(transform);
		}
	}

	public void RaiseOnLightOn()
	{
		if (onLightOn != null)
		{
			onLightOn(transform);
		}
	}


	public void CoolDown(float seconds)
	{
		RaiseOnLightOff();
		IsLightOn = false;
		gameObject.GetComponentInChildren<Light>().enabled = false;
		StartCoroutine(TurnOnAfterTime(seconds));
	}

	IEnumerator TurnOnAfterTime(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		RaiseOnLightOn();
		gameObject.GetComponentInChildren<Light>().enabled = true;
		IsLightOn = true;
	}
}
