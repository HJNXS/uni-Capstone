using UnityEngine;
/*
public class VaultButton : MonoBehaviour
{
    public GameEvent buttonEventTest;

    
}
*/

public class VaultButton: MonoBehaviour
{
	public System.Action<VaultButton,Collider> TriggerStay;

	private void OnTriggerStay(Collider other)
	{
		if(TriggerStay != null)
			TriggerStay(this, other);
	}
}
