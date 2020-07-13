using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using levelOrganisation;
using Rewired;

/// <summary>
/// SceneManage is used together with event handler to switch 
/// between scene by different behaviour (fading, normal)
/// It uses prefabs to instantiate a gameobject. 
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>01/08/18</LastEdited>
public class SceneManage : MonoBehaviour {

	public List<CustomScene> levelLists;

	public Animator blackfadingAnimator;

    public int index = 0; //made public for debugging
	private bool isFadeCompleted = false;

	private void Update()
    {
        
		if (levelLists[index] is LevelScene)
			(levelLists[index] as LevelScene).UpdateLevel();
    }

	private void NextScene()
	{
        index++;
	}

	private void Reset()
	{
		index = 0;
	}
	
	public void ResetGame()
	{
		ReInput.players.GetPlayer(0).StopVibration();
        StartCoroutine(LoadAsyncSceneFade(0));
	}

	public void NextSceneNormal()
    {
		NextScene();
        StartCoroutine(LoadAsyncScene(levelLists[index].sceneID));
    }

    public void NextSceneFade()
    {
		NextScene();
        StartCoroutine(LoadAsyncSceneFade(levelLists[index].sceneID));
    }

	public void ResetSceneNormal()
    {
		Reset();
		ReInput.players.GetPlayer(0).StopVibration();
        StartCoroutine(LoadAsyncScene(levelLists[index].sceneID));
    }

    public void ResetSceneFade()
    {
		Reset();
		ReInput.players.GetPlayer(0).StopVibration();
		StartCoroutine(LoadAsyncSceneFade(levelLists[index].sceneID));
    }
	
	/// <summary>
	///	Changes state of boolean to allow loeading scene. 
	/// </summary>
	/// <remarks>Call inside the animator component</remarks>
	public void OnFadeComplete()
	{
		isFadeCompleted = true;	
	}

    IEnumerator LoadAsyncScene(int sceneId)
    {
		AsyncOperation result;
		result = SceneManager.LoadSceneAsync(sceneId);

		//Wait until the last operation fully loads to return anything
		while (!result.isDone)
        {
            Debug.Log(result.progress);
            yield return null;
        }
    }
	
    IEnumerator LoadAsyncSceneFade(int sceneId)
    {
		AsyncOperation result;
		result = SceneManager.LoadSceneAsync(sceneId);
		result.allowSceneActivation = false;

		blackfadingAnimator.SetTrigger("FadeBlack");
		Time.timeScale = 0f;

		//Wait until the last operation fully loads to return anything
		while (!result.isDone && !isFadeCompleted)
        {
            yield return null;
        }
		result.allowSceneActivation = true;
		Time.timeScale = 1f;
    }
}
