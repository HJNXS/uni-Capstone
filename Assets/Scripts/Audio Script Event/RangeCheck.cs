using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// RangeCheck raise an event when entity is in range
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>21/09/18</LastEdited>
public class RangeCheck : MonoBehaviour
{

	public float radius;

	public Transform entity;

	public LayerMask entityMask;

	public GameEvent gameEvent;

	// Update is called once per frame
	void Update () {
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, entityMask);
		if (hitColliders.Length > 0)
		{
			if (!gameEvent.IsDisable)
			{
				gameEvent.Invoke();
				gameEvent.IsDisable = true;
			}
		}
	}
}
