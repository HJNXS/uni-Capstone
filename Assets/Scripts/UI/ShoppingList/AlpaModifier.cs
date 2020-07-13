using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlpaModifier : MonoBehaviour {

	private Image image;

	private void Start()
	{
		image = transform.GetComponent<Image>();
	}

	public void ChangeAlpha(float value = 0.1f)
	{
		image.color = new Color(image.color.r, image.color.g, image.color.b, value);
	}
}
