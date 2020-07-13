using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static class handling disable and activating of physics
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>18/08/18</LastEdited>
public static class RigidbodySetter{

	/// <summary>
	/// Set or disable physics on objects having rigidbody.
	/// </summary>
	/// <param name="allowPhysics"></param>
	public static void setRigidbodyPhysics(bool allowPhysics, List<GameObject> disableObjects)
	{
			foreach (GameObject obj in disableObjects)
			{
				obj.GetComponent<Rigidbody>().isKinematic = allowPhysics;
				Rigidbody[] allChildren = obj.GetComponentsInChildren<Rigidbody>();
				foreach (Rigidbody childRb in allChildren)
				{
					childRb.isKinematic = allowPhysics;
				}
			}
	}
}
