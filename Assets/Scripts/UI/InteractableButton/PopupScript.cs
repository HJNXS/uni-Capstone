using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles popUp appearing when player is nearby
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>25/08/18</LastEdited>
public class PopupScript : MonoBehaviour {

    public GameObject popUp;
    public GameObject player;
    public Transform setPos;
    private GameObject instantiatedPopUp;

    private GlowObject glowObject;

    private bool isInteractable; 

	// Use this for initialization
	void Start () {

		//glowObject = GetComponent<GlowObject>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];

    }

	public void setPopUp(GameObject lpopUp)
	{
		popUp = lpopUp;
		//Position of object

		instantiatedPopUp = Instantiate(popUp); //Instantiate(popUp, newPos, Quaternion.identity);
        instantiatedPopUp.transform.parent = transform;
		Vector3 newPos;
		if (setPos == null)
			 newPos = new Vector3(transform.position.x, gameObject.GetComponent<MeshRenderer>().bounds.size.y + 1f, transform.position.z);
		else
			newPos = setPos.position;
		instantiatedPopUp.transform.position = newPos;
		instantiatedPopUp.GetComponent<Canvas>().enabled = false;

		IsInteractable = true;
	}

	private void Update()
	{
		if (instantiatedPopUp != null)
			instantiatedPopUp.transform.LookAt(Camera.main.transform.position);
	}

	/// <summary>
	/// Is the object no longer interactable in the game?
	/// </summary>
	/// <remarks>To not confuse with wether object is active or not. Use by puzzle to set button disable</remarks>
	public bool IsInteractable
    {
        get { return isInteractable; }
        set
        {
            ChangeState(value);
            isInteractable = value;
        }
    }

    public void ChangeState(bool changeBool)
    {
        if (IsInteractable)
        {
            //glowObject.ChangeGlowState(changeBool);
			instantiatedPopUp.GetComponent<Canvas>().enabled = changeBool;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if ((int)other.gameObject.layer == LayerMask.NameToLayer("Player"))
    //    {
    //        ChangeState(true);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if ((int)other.gameObject.layer == LayerMask.NameToLayer("Player"))
    //    {
    //        ChangeState(false);
    //    }
    //}
}
