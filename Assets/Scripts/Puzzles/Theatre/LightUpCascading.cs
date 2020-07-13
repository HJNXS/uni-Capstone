using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles turning a list of lights in sequence when
/// player hit trigger
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>02/09/18</LastEdited>
public class LightUpCascading : MonoBehaviour {
	
	/// <summary>
	/// Contains list of lights in order of lighting sequence
	/// </summary>
	public List<Light> lights;

	public float elapseTime;

	private int index = 0;

	private bool oneTime = true;

	private Coroutine ElapseCoroutine = null;

	private void OnTriggerEnter(Collider other)
	{
		if (oneTime)
		{
			if (other.tag == "Player")
			{
				oneTime = false;
				TurnOnTwoLights();
				StartCoroutine(UntilSequenceFinishes());
			}
		}

	}

	private void TurnOnTwoLights()
	{
		int length = index + 2;
		for (; index < length; index++)
		{
			lights[index].enabled = true;
		}
	}

	IEnumerator UntilSequenceFinishes()
	{
		while(!lights[lights.Count - 1].enabled)
		{
			yield return StartCoroutine(TurnLightInSequence());
		}
	}

	IEnumerator TurnLightInSequence()
	{
		Debug.Log(Time.time);
		yield return new WaitForSeconds(elapseTime);
		Debug.Log("Finsish - " + Time.time);
		TurnOnTwoLights();
	}

}
