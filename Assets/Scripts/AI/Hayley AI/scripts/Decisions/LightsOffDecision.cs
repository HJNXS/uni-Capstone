using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PlugAi/Decisions/LightsOff")]
public class LightsOffDecision : Decision {

    public override bool Decide(StateController controller)
    {
        bool LightsOn = IsLight(controller);
        return LightsOn;
    }
    
    //Check IsLightOn in LightsDown Script...
    private bool IsLight(StateController controller)
    {
        if (controller.lightInfoPos != null) //is there a light off?
        {
            for (int i = 0; i < controller.lightInfoPos.Count; i++)
            {
                //is it close to the guard?
                if (Vector3.Distance(controller.transform.position, controller.lightInfoPos[i].position) < 5f == true)
                {
                    controller.confusedParticle.Play();
                    return true;
                }
                else
                    return false;
            }
        }
        return false;
    }
}
