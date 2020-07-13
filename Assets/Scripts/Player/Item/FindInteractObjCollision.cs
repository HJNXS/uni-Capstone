using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FindInteractObjCollision finds objects that the entity can interact with
/// using collision and organising it inside a list of gameobject.
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>28/07/18</LastEdited>
public class FindInteractObjCollision : MonoBehaviour {

	[Header("Interactable Item Details")]
	public LayerMask interactableMask;

	public Transform parentPickUpObj;

	[SerializeField]
	private List<GameObject> inVicinity = new List<GameObject>();

	public List<GameObject> Invicinity
	{
		get { return inVicinity; }
	}

	private void OnTriggerEnter(Collider other)
    {
		if (parentPickUpObj.childCount == 0)
		{
			if (((1 << other.gameObject.layer) & interactableMask.value) != 0)
			{
				if (other.gameObject.GetComponent<PopupScript>())
				{
					other.gameObject.GetComponent<PopupScript>().ChangeState(true);
					inVicinity.Add(other.gameObject);
				}
			}
		}
    }

    private void OnTriggerExit(Collider other)
    {
		if (parentPickUpObj.childCount == 0)
		{
			if (((1 << other.gameObject.layer) & interactableMask.value) != 0)
			{
				if (other.gameObject.GetComponent<PopupScript>())
				{
					other.gameObject.GetComponent<PopupScript>().ChangeState(false);
					Remove(other.gameObject);
				}
			}
		}
    }

	public void Remove(GameObject obj)
	{
		inVicinity.Remove(obj);
	}

	public void Clear()
	{
		inVicinity.Clear();
	}
}
