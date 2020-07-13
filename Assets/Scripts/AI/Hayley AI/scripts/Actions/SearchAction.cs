using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Look around in 180 degrees.
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>05/10/2018</LastEdited>
[CreateAssetMenu (menuName = "PlugAi/Actions/Search")]
public class SearchAction : Action {

	private StateController fController;

	public override void Act(StateController controller)
    {
		fController = controller;
		Search();
    }

	private void Search()
	{
		if (fController.searchOneTime)
		{
			fController.onStateChange += delegate ()
			{
				fController.searchOneTime = true;
			};
			fController.searchOneTime = false;
			float delay = fController.waitTime / 3f;
			iTween.RotateAdd(fController.gameObject, iTween.Hash("amount", new Vector3(0f, 30f, 0f), "time", delay * 0.9f, "easeType", iTween.EaseType.easeInQuad));
			fController.StartCoroutine(RotateDelay(delay - delay * 0.1f, -60f));
			fController.StartCoroutine(RotateDelay(delay * 2f - delay * 0.1f, 30f));
		}
	}

	IEnumerator RotateDelay(float delay, float degree)
	{
		yield return new WaitForSeconds(delay);
		iTween.RotateAdd(fController.gameObject, iTween.Hash("amount", new Vector3(0f, degree, 0f), "time", delay, "easeType", iTween.EaseType.easeInQuad));
		fController.StartCoroutine(Delay(delay));
	}

	IEnumerator Delay(float delay)
	{
		yield return new WaitForSeconds(delay);
	}
}
