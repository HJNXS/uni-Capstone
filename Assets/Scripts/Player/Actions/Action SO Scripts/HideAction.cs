using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HardlightAnvil.RunWithIt.Actions
{
[CreateAssetMenu(menuName = "Actions/Hide")]
public class HideAction : OldAction
{
    
    public override void Execute(GameObject player, GameObject target, bool isAllowed)
    {
        MeshRenderer meshRenderer;
        if (player.GetComponentInChildren<MeshRenderer>().isVisible)
        {
            player.GetComponentInChildren<MeshRenderer>().enabled = false;
            player.GetComponent<InputHandler>().enabled = false;
            meshRenderer = target.GetComponentInChildren<MeshRenderer>();
            meshRenderer.material.color = Color.red;
        }
        else
        {
            player.GetComponentInChildren<MeshRenderer>().enabled = true;
            player.GetComponent<InputHandler>().enabled = true;
            meshRenderer = target.GetComponentInChildren<MeshRenderer>();
            meshRenderer.material.color = Color.white;
        }
    }
/*
    public override PlayerActions GetName()
    {
        return PlayerActions.Hide;
    } */
}
}