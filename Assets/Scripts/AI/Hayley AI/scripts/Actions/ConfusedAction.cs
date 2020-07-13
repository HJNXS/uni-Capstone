using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Actions performed by AI during confused: Stop agent from moving and play animation
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>02/10/2018</LastEdited>
[CreateAssetMenu (menuName = "PlugAi/Actions/Confused")]
public class ConfusedAction : Action {

    public override void Act(StateController controller)
    {
        Confuse(controller);
    }

    private void Confuse(StateController controller)
    {
		if (controller.confusedParticle.isPlaying == false)
		{
            //controller.confusedParticle.Play();
            controller.gridAgent.StopPathing();
		}
	}
}
