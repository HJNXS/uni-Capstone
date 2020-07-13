using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Actions performed by AI during pause: Disable Movement
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>30/09/2018</LastEdited>
[CreateAssetMenu (menuName = "PlugAi/Actions/Pause")]
public class PauseAction : Action {

    public override void Act(StateController controller)
    {
		//Note: Need to deal with resume the previous state
		controller.gridAgent.StopPathing();
	}
}
