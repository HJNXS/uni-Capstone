using UnityEngine;

public class KeyVisuals : MonoBehaviour
{
    public KeyManager keyManager;
    public GameObject[] KeysVisuals;

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
        foreach (var go in KeysVisuals)
        {
            if (go.activeSelf)
                continue;

            go.SetActive(true);
            break;
        }
    }
}
