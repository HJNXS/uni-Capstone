using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GazeboUIManager : MonoBehaviour
{
    public Image TextBox;
    public Text CollectKeysMessage;
    public float CollectMessageUILength = 10;

    public Text KeysFoundText;
    public float FoundMessageUILength = 10;

    public Text KeyPerminentUI;

    public float KeyPickedUpStillDuration = 2;
    public float KeyPickupAnimationSpeed = 0.5f;
    public float KeyPickupAnimationStopDistance = 2;
    public Image KeyAnimatedIcon;
    public Image KeyPerminentIcon;
    Vector3 StartPos;
    public KeyManager keyManager;

    private void OnEnable()
    {
        KeyCollectable.OnPickUp += KeyPickedUp;
        keyManager.OnAllKeysPickedUp += AllKeysPickedUp;
    }

    private void OnDisable()
    {
        KeyCollectable.OnPickUp -= KeyPickedUp;
        keyManager.OnAllKeysPickedUp -= AllKeysPickedUp;
    }

    private void AllKeysPickedUp()
    {
        StartCoroutine(DoShowMessage(KeysFoundText, FoundMessageUILength));
    }

    public void Start()
    {
        //StartPos = KeyAnimatedIcon.transform.position;
        //KeyAnimatedIcon.gameObject.SetActive(false);
        StartCoroutine(DoShowMessage(CollectKeysMessage, CollectMessageUILength));
    }

    private IEnumerator DoShowMessage(Text obj, float duration)
    {
        TextBox.gameObject.SetActive(true);
        obj.gameObject.SetActive(true);

        yield return new WaitForSeconds(duration);

        obj.gameObject.SetActive(false);
        TextBox.gameObject.SetActive(false);
    }

    private void KeyPickedUp(KeyCollectable obj)
    {
		UpdateText(keyManager.KeysPickedUp + 1);
		//DoKeyAnimantion();
    }

    //private void DoKeyAnimantion()
    //{
    //    StartCoroutine(KeyAnimation());
    //}

 //   private IEnumerator KeyAnimation()
	//{
	//	KeyAnimatedIcon.gameObject.SetActive(true);

	//	UpdateText(keyManager.KeysPickedUp + 1);
	//	yield return new WaitForSeconds(KeyPickedUpStillDuration);

		//while(true)
		//{
		//	var deltaTime = Time.deltaTime;
		//	var currentPos = KeyAnimatedIcon.rectTransform.position;
		//	var destinationPos = KeyPerminentIcon.rectTransform.position;

		//	var finalPos = GetAnimatedPosition(currentPos,destinationPos,deltaTime * KeyPickupAnimationSpeed);

		//	KeyAnimatedIcon.rectTransform.position = finalPos;
		//	yield return null;
		//	if(Vector3.Distance(destinationPos,finalPos) < KeyPickupAnimationStopDistance)
		//		break;
		//}

		//KeyAnimatedIcon.gameObject.SetActive(false);
		//KeyAnimatedIcon.rectTransform.position = StartPos;
		//UpdateText();
	//}

	private void UpdateText()
	{
		UpdateText(keyManager.KeysPickedUp);
	}

	private void UpdateText(int num)
	{
		if(keyManager.Keys.Length == num)
		{
			KeyPerminentUI.text = "All Keys Found";
			keyManager.KeysPickedUp++;
			AllKeysPickedUp();
		}
		else
		{
			KeyPerminentUI.text = num + "/3 Keys Found";
		}
	}

	//private static Vector3 GetAnimatedPosition(Vector3 currentPos, Vector3 destinationPos, float deltaTime)
 //   {
 //       return new Vector3(
 //           Mathf.Lerp(currentPos.x, destinationPos.x, deltaTime),
 //           Mathf.Lerp(currentPos.y, destinationPos.y, deltaTime * 2),
 //           Mathf.Lerp(currentPos.z, destinationPos.z, deltaTime)
 //           );
 //   }
}
