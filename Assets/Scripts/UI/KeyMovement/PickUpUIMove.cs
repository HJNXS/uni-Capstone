﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpUIMove : MonoBehaviour
{
	[Range(-1000f, 1000f)]
	public float TargetPositionLeft = -450f;
	[Range(-1000f, 1000f)]
	public float TargetPositionTop = 160f;
	[Range(0.001f, 1000f)]
	public float Speed = 1.0f;
	public float closeEnough;

	private Vector2 targetPosition;
	private Vector2 currentPosition;
	private RectTransform objTrans;
	private float distanceToTarget;

	public GameObject ResourceImage;

	// Use this for initialization
	void Start ()
	{
		//Get a reference to the UI object
		objTrans = GetComponent<RectTransform> ();

		//Get its current position
		currentPosition = objTrans.anchoredPosition;

		//Get a reference to where we want it to go
		targetPosition = new Vector2(TargetPositionLeft, TargetPositionTop);
	}

	// Update is called once per frame
	void Update ()
	{
		//Get a position that is a little bit closer to our goal position
		objTrans.anchoredPosition = Vector2.Lerp(currentPosition, targetPosition, Speed * Time.deltaTime);

		//Set our object to that new position
		currentPosition = objTrans.anchoredPosition;

		//How far are we from our goal?
		distanceToTarget = Vector2.Distance (currentPosition, targetPosition);
	}

	void LateUpdate()
	{
		//If we are close enough and we want the icon to disappear...
		if (distanceToTarget < closeEnough)
		{
			//Bonus: Make the default icon animate as the new resource is brought in
			//Swell the resource icon

			//Destroy the object, we are done with it!
			Destroy (gameObject);
		}
	}
}
