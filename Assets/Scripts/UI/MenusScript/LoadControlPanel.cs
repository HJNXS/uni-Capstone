using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Set the control panel active
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>01/10/18</LastEdited>
/// <Remarks>Call in camera animation event</LastEdited>
public class LoadControlPanel : MonoBehaviour {

	public GameObject ControlPanel;

	public void SetActive()
	{
		ControlPanel.SetActive(true);
	}
}
