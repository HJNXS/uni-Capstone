using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Allow physics to crate rigidbody to create crates breaking,
/// when the trigger is hit.
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>05/09/18</LastEdited>
public class FlatCollider : MonoBehaviour {

	public float waitSec = 0.0f;
	public GameObject frame;
	public List<GameObject> crates;

	public GameEvent openGarageDoor;

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Falling Frame")
		{
			RigidbodySetter.setRigidbodyPhysics(false, crates);
			StartCoroutine(StopRigidBody());
		}
	}

	/// <summary>
	///	Disable physics to objects after a period of time.
	/// </summary>
	/// <remarks>
	/// Create movement between objects when rigidbody collides with themselves,
	/// avoid it by disabling it. 
	/// </remarks>
	/// <returns></returns>
	IEnumerator StopRigidBody()
	{
		yield return new WaitForSeconds(waitSec);
		frame.GetComponent<Rigidbody>().isKinematic = true;
		RigidbodySetter.setRigidbodyPhysics(true, crates);
		openGarageDoor.Invoke();
	}
}
