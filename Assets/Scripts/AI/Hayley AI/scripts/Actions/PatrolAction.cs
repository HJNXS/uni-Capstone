using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Actions performed by AI during patrol: moving between waypoints.
/// </summary>
/// <PrimaryContributor>Hayley Kumpis</PrimaryContributor>
/// <LastEdited>11/09/2018</LastEdited>
/// <remarks>Look at Animations.</remarks>
[CreateAssetMenu (menuName = "PlugAi/Actions/Patrol")]
public class PatrolAction : Action {

    public override void Act(StateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(StateController controller)
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
            controller.pointReached = true;
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.waypointList.Count;
            controller.AIanimator.SetBool("Walk", false);
        }
        
        

    }
}
