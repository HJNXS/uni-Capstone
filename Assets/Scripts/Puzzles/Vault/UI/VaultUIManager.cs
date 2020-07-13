using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VaultUIManager : MonoBehaviour
{
    public Image TextBox;

    public Text StartObjective;
    public float StartObjectivePopupTime = 5;

    public Text LeverPulledObjective;
    public float LeverPulledObjectivePopupTime = 5;

    public Text LightsObjective;
    public float LightsObjectivePopupTime = 5;

    public Text CollectKeyObjective;
    public float CollectKeyObjectivePopupTime = 5;

    public Text EscapeObjective;
    public float EscapeObjectivePopupTime = 5;
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
    }

    private void OnDisable()
    {
        KeyCollectable.OnPickUp -= KeyPickedUp;
    }
    public void Start()
    {
        StartCoroutine(DoShowMessage(StartObjective, StartObjectivePopupTime));
    }

    private IEnumerator DoShowMessage(Text obj, float duration)
    {
        TextBox.gameObject.SetActive(true);
        obj.gameObject.SetActive(true);

        yield return new WaitForSeconds(duration);

        obj.gameObject.SetActive(false);
        TextBox.gameObject.SetActive(false);
    }

    public void LeverPulled()
    {
        StartCoroutine(DoShowMessage(LeverPulledObjective, LeverPulledObjectivePopupTime));
    }

    public void LightPuzzleComplete()
    {
        StartCoroutine(DoShowMessage(LightsObjective, LightsObjectivePopupTime));
    }

    public void Escape()
    {
        StartCoroutine(DoShowMessage(EscapeObjective, EscapeObjectivePopupTime));
    }

    public void CollectKey()
    {
        StartCoroutine(DoShowMessage(CollectKeyObjective, CollectKeyObjectivePopupTime));
    }

    private void KeyPickedUp(KeyCollectable obj)
    {
		keyManager.KeysPickedUp++;
		UpdateText();
        //DoKeyAnimantion();
    }

 //   private void DoKeyAnimantion()
 //   {
 //       StartCoroutine(KeyAnimation());
 //   }

 //   private IEnumerator KeyAnimation()
	//{
	//	KeyAnimatedIcon.gameObject.SetActive(true);

	//	UpdateText();

	//	yield return new WaitForSeconds(KeyPickedUpStillDuration);

	//	while(true)
	//	{
	//		var deltaTime = Time.deltaTime;
	//		var currentPos = KeyAnimatedIcon.rectTransform.position;
	//		var destinationPos = KeyPerminentIcon.rectTransform.position;

	//		var finalPos = GetAnimatedPosition(currentPos,destinationPos,deltaTime * KeyPickupAnimationSpeed);

	//		KeyAnimatedIcon.rectTransform.position = finalPos;
	//		yield return null;
	//		if(Vector3.Distance(destinationPos,finalPos) < KeyPickupAnimationStopDistance)
	//			break;
	//	}

	//	KeyAnimatedIcon.gameObject.SetActive(false);
	//	KeyAnimatedIcon.rectTransform.position = StartPos;
	//	UpdateText();
	//}

	private void UpdateText()
	{
		KeyPerminentUI.text = "All Keys Found";
	}

	private static Vector3 GetAnimatedPosition(Vector3 currentPos, Vector3 destinationPos, float deltaTime)
    {
        return new Vector3(
            Mathf.Lerp(currentPos.x, destinationPos.x, deltaTime),
            Mathf.Lerp(currentPos.y, destinationPos.y, deltaTime * 2),
            Mathf.Lerp(currentPos.z, destinationPos.z, deltaTime)
            );
    }
}
