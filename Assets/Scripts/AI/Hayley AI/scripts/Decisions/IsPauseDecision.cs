using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stay idle while game is pause or cutscene
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>30/09/2018</LastEdited>
[CreateAssetMenu (menuName = "PlugAi/Decisions/Pause")]
public class IsPauseDecision : Decision {

    public override bool Decide(StateController controller)
    {
        if (controller.isPause == false)
        {
            controller.confusedParticle.Stop();
            return false;
        }
        else
            return true;

    }
}
