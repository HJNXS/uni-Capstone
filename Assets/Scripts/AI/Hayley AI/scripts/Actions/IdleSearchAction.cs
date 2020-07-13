using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Look around in 90 degrees and wait and then continue.
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>12/10/2018</LastEdited>
[CreateAssetMenu (menuName = "PlugAi/Actions/IdleSearch")]
public class IdleSearchAction : Action {

	public override void Act(StateController controller)
    {
		SearchIdle(controller);
    }

	private void SearchIdle(StateController controller)
	{
		if (!controller.GetComponent<iTween>() && controller.coroutineHolder == null)
		{
			controller.coroutineHolder = controller.StartCoroutine(Delay(controller.waitTimeSearchIdl, controller));
			if (!controller.toggle)
			{
				iTween.RotateAdd(controller.gameObject, iTween.Hash("amount", new Vector3(0f, -90f, 0f), "time", 3f, "easeType", iTween.EaseType.easeInQuad));
				controller.toggle = !controller.toggle;
			}
			else
			{
				iTween.RotateAdd(controller.gameObject, iTween.Hash("amount", new Vector3(0f, 90f, 0f), "time", 3f, "easeType", iTween.EaseType.easeInQuad));
				controller.toggle = !controller.toggle;
			}
		}
	}

	IEnumerator Delay(float sec, StateController controller)
	{
		yield return new WaitForSeconds(sec);
		controller.coroutineHolder = null;
	}
}
