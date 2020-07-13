using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Rewired;
using levelOrganisation;

/// <summary>
/// UIControlCheck handles asynchronous loading of scene and displaying
/// progress to user while user is waiting.
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>01/08/18</LastEdited>
public class UIControlCheck : MonoBehaviour {

    public int playerId = 0;
	public Text txt;

	public CustomScene scene;

	public void LoadNextLevel()
	{
		StartCoroutine(LoadGameScene());
	}

	IEnumerator LoadGameScene()
	{
		AsyncOperation result;
		result = SceneManager.LoadSceneAsync(scene.sceneID);
		result.allowSceneActivation = false;

		while(!result.isDone)
		{
			float progress = Mathf.Clamp01(result.progress / 0.9f);
			txt.text = (Mathf.RoundToInt(progress) * 100) + "%";

			if (result.progress == 0.9f)
			{
				result.allowSceneActivation = true;
			}
			yield return null;
		}
	}

	public void LoadGameSceneSimple()
	{
		SceneManager.LoadSceneAsync(scene.sceneID);
	}
}
