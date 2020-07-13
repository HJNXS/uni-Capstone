using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// chase player until they die/are inactive
/// </summary>
/// <PrimaryContributor>Hayley Kumpis</PrimaryContributor>
/// <LastEdited>07/09/2018</LastEdited>
/// <remarks> NEED TO REPLASE WITH CHASE UNTIL LOSE SIGHT OF PLAYER, BUT STILL HEAD TO LAST KNOWN POSITION</remarks>

[CreateAssetMenu (menuName = "PlugAi/Decisions/ActiveState")]
public class ActiveStateDecision : Decision {

    public override bool Decide(StateController controller)
    {
        //chase till player is dead

        bool chaseTargetIsActive = controller.chaseTarget.gameObject.activeSelf;
        return chaseTargetIsActive;
    }

}
