using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Has AI reached waypoint? if yes, change state.
/// </summary>
/// <PrimaryContributor>Hayley Kumpis</PrimaryContributor>
/// <LastEdited>11/09/2018</LastEdited>
[CreateAssetMenu(menuName = "PlugAi/Decisions/ReachWP")]
public class reachWPDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool reachedWP = CheckPoint(controller);
        return reachedWP;
    }

    public bool CheckPoint(StateController controller)
    {
        if (controller.pointReached == true)
            return true;
        else
            return false;
    }
}
