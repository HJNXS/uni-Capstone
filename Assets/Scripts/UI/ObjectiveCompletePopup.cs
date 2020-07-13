using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ObjectiveCompletePopup handles the amount of time a UI component
/// to show on screen.
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>07/09/18</LastEdited>
public class ObjectiveCompletePopup : MonoBehaviour
{
	public float elapseTime = 2f;

	private void OnEnable()
	{
		showComplete();
	}

	IEnumerator showComplete()
	{
		yield return new WaitForSeconds(elapseTime);
		gameObject.SetActive(false);
	}

}
