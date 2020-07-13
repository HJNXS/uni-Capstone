using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoorVault : MonoBehaviour {

	public enum Side { Left, Right};

	public void RotateDoorLeft()
    {
		transform.Rotate(new Vector3(0, 0, 1), 100f);
    }
	public void RotateDoorRight()
	{
		transform.Rotate(new Vector3(0, 0, 1), 100f);
	}
}
