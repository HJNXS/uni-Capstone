using UnityEngine;
using ForestOfChaosLib.Extensions;

public class KeyManager : MonoBehaviour
{
    public int KeysPickedUp;
	public GameEvent AllKeyCollected;
    public KeyCollectable[] Keys;
    public event System.Action OnAllKeysPickedUp;

    private void OnEnable()
    {
        KeyCollectable.OnPickUp += OnKeyPickup;
    }

    private void OnDisable()
    {
        KeyCollectable.OnPickUp -= OnKeyPickup;
    }

    private void OnKeyPickup(KeyCollectable obj)
    {
        if (KeysPickedUp == Keys.Length)
        {
            OnAllKeysPickedUp.Trigger();
			AllKeyCollected.Invoke();
        }
		else
		{
            KeysPickedUp++;
		}
    }

    public bool IsDone { get { return KeysPickedUp == Keys.Length; } }
}
