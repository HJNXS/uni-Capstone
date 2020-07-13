using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneTookOut : MonoBehaviour {

	public float waitSec = 0.0f;
	public List<GameObject> bones;

	public void boneTaken()
	{
		RigidbodySetter.setRigidbodyPhysics(false, bones);
		StartCoroutine(StopRigidBody());
	}

	/// <summary>
	///	Disable physics to objects after a period of time.
	/// </summary>
	/// <remarks>
	/// Create movement between objects when rigidbody collides with themselves,
	/// avoid it by disabling it. 
	/// </remarks>
	IEnumerator StopRigidBody()
	{
		yield return new WaitForSeconds(waitSec);
		RigidbodySetter.setRigidbodyPhysics(true, bones);
	}
}
