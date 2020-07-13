using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableButton : MonoBehaviour {

	public void disableButton()
	{
		gameObject.GetComponent<PopupScript>().IsInteractable = false;
	}
}
