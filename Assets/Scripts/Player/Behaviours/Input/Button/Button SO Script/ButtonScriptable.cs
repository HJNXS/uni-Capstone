using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Acts like a container for the actions the button can execute,
/// and on which object it can execute those actions using objects layer mask
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>13/09/18</LastEdited>
[CreateAssetMenu(menuName = "Player Button/Create Button")]
public class ButtonScriptable : ScriptableObject {

	public string buttonName;
	public List<LayerMask> actionLayerMask;
	public List<OldAction> buttonAction;
}
