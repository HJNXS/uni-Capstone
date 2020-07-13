using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

/// <summary>
///when chacing target, checking if it is in sight. if not, still moves to last known pos.
/// </summary>
/// <PrimaryContributor>Hayley Kumpis</PrimaryContributor>
/// <LastEdited>11/09/2018</LastEdited>
[CreateAssetMenu(menuName = "PlugAi/Decisions/ChaseLook")]
public class chaselookDecision : Decision
{

	//is the guard not moving, aka at agent arrived? 
	//If yes: return true to change state to search
	//if no:  remain. 
    public override bool Decide(StateController controller)
    {
        bool targetVisable = ChaseLook(controller);
        return targetVisable;
    }
    private bool ChaseLook(StateController controller)
    {
		//here
        if ((controller.gridAgent.AgentArrived == true || controller.gridAgent.nodesToPath.Count == 0) && controller.AIfov.visibleTargets.Count == 0)
        {
			//change state
			controller.speed = 3.5f;
            Color searchColor = new Color32(255, 255, 255, 41);

            Material mat = controller.Visual.material;
            mat.color = searchColor;
            controller.Visual.material = mat;
			controller.ActualSpeed = controller.speed;
			ReInput.players.GetPlayer(0).StopVibration();
			return true;
        }
        else
            return false; // remain

    }

}
