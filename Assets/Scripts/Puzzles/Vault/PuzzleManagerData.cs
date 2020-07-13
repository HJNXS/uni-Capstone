using UnityEngine;

[CreateAssetMenu(fileName = "New Puzzle Manager Data", menuName = "Puzzle/Manager Data")]
public class PuzzleManagerData : ScriptableObject
{
	[SerializeField]
	private bool complete;

	public System.Action<bool> OnCompleteChanged;
	public bool Complete
	{
		get { return complete; }
		set
		{
			complete = value;

			if(OnCompleteChanged != null)
				OnCompleteChanged(value);
		}
	}

	private void Reset()
	{
		complete = false;
	}

	private void OnEnable()
	{
		complete = false;
	}
}
