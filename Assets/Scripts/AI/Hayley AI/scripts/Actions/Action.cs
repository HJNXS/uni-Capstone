using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Any recuring actions AI performs inside a state.
/// </summary>
/// <PrimaryContributor>Hayley Kumpis</PrimaryContributor>
/// <LastEdited>11/09/2018</LastEdited>
/// <remarks>Overwritten by specific action scripts. Implemented via scriptables.</remarks>
public abstract class Action : ScriptableObject {

    public abstract void Act(StateController controller);

    public static Quaternion GetLookRotation(StateController controller, Vector3 dest)
    {
        var dir = dest - controller.transform.position;
        dir.Normalize();
        var rot = Quaternion.Lerp(controller.transform.rotation, Quaternion.LookRotation(dir, Vector3.up), Time.deltaTime * 4);
        return rot;
    }

}
