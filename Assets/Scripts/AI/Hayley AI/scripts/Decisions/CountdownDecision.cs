using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Changes state once countdown finished. 
/// </summary>
/// <PrimaryContributor>Hayley Kumpis</PrimaryContributor>
/// <LastEdited>11/09/2018</LastEdited>
[CreateAssetMenu (menuName = "PlugAi/Decisions/Scan")]
public class CountdownDecision : Decision {

    public override bool Decide(StateController controller)
    {
        bool noEnemyInSight = Scan(controller);
        return noEnemyInSight;
    }

    private bool Scan(StateController controller)
    {
		//Debug.Log("ADD ROTATE WITH HEAD??");
		//controller.transform.Rotate(0, controller.AiStats.searchingTurnSpeed * Time.deltaTime, 0);
		if (!controller.confusedParticle.isStopped)
			controller.confusedParticle.Stop();
		if (controller.CheckIfCountdownElapsed(controller.waitTime) && controller.waypointList.Count > 1)
		{
			controller.searchOneTime = false;
			return true;
		}
		return false;
    }
}
