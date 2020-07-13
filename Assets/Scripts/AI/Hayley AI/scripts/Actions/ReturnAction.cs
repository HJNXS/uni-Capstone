using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Make player return to the spot it was idling
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>12/10/2018</LastEdited>
[CreateAssetMenu (menuName = "PlugAi/Actions/Return")]
public class ReturnAction : Action {

	public override void Act(StateController controller)
    {
		ReturnToSpot(controller);
    }

	private void ReturnToSpot(StateController controller)
	{
        controller.AIanimator.SetBool("Pause", false);
       
        controller.AIanimator.SetBool("Walk", true);
        Vector3 dest = controller.waypointList[controller.nextWayPoint].position;
        if (controller.gridAgent.AgentArrived == false)
        {
            controller.gridAgent.SetDestination(dest, controller.ActualSpeed);
        }
		else
		{
			//make the turning to the right angle then say pointreached 
		}
	}
}
