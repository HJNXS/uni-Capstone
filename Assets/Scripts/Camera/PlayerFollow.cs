using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerFollow : MonoBehaviour {

    public Transform player;
    public Transform environment;

    public int playerId = 0;

    private Vector3 _cameraOffset;

    public bool LookAtPlayer = true;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    [Range(10f, 40f)]
    public float distance = 10f;

    public bool RotateAroundPlayer = true;

    [Range(5f, 30f)]
    public float RotationSpeed;

    [Range(1f, 5f)]
    public float LerpRotationSpeed;

	private float cameraHorizontalInput = 0.0f;

	Quaternion camTurnAngle;

	private void Start()
    {
        _cameraOffset = (transform.position - environment.position).normalized * distance;
    }

    private void LateUpdate()
    {
        if(RotateAroundPlayer)
        {
			cameraHorizontalInput = ReInput.players.GetPlayer(playerId).GetAxis("CHorizontal");
            camTurnAngle = Quaternion.AngleAxis(cameraHorizontalInput * RotationSpeed, Vector3.up);

			float intervalAngleLimit = (Mathf.Sign(cameraHorizontalInput) > 0) ? (Mathf.RoundToInt(transform.eulerAngles.y / 30) * 30)
				: (Mathf.RoundToInt(transform.eulerAngles.y / 30) * 30) - 30f;
			if (transform.eulerAngles.y < intervalAngleLimit)
			{
				StartCoroutine(LerpCameraToLimit(intervalAngleLimit));
			}
			_cameraOffset = camTurnAngle * _cameraOffset;
        }

        Vector3 newPos = player.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if (LookAtPlayer || RotateAroundPlayer)
            transform.LookAt(player);
    }

	IEnumerator LerpCameraToLimit(float limit)
	{
		while (transform.eulerAngles.y < limit)
		{
			camTurnAngle = Quaternion.AngleAxis(Mathf.Sign(cameraHorizontalInput) * LerpRotationSpeed, Vector3.up);
			yield return null;
		}
	}
}
