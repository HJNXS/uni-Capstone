using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Currently used to constanly check for player within a spherecast range. will be replaced with field of view.
/// </summary>
/// <PrimaryContributor>Hayley Kumpis</PrimaryContributor>
/// <LastEdited>11/09/2018</LastEdited>
[CreateAssetMenu (menuName = "PlugAi/Decisions/Look")]
public class lookDecision : Decision {

    public override bool Decide(StateController controller)
    {
        bool targetVisable = Look(controller);
        return targetVisable;
    }
    private bool Look(StateController controller)
    {
        FieldOfView fieldOfView = controller.AIfov;
        fieldOfView.FindVisibleTargets();

        if (fieldOfView.visibleTargets.Count != 0)
        {
            
			controller.guardNoticeEvent.Invoke();
            controller.chaseTarget = fieldOfView.visibleTargets[0].transform; //should change this to ref of player?
			controller.gridAgent.StopPathing();

            Color chaseColor = new Color32(248, 16, 16, 92);
            
            Material mat = controller.Visual.material;
            mat.color = chaseColor;
            controller.Visual.material = mat;
            
            return true;
        }
        return false;

        
    }
}
