using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour {

    private GameObject[] levelList;

    public Text abstractText;
    public Text nameText;

    public Level[] levelSO; //Note: need to follow order of the world prefab in scene

    private int index;

	void Start () {
        levelList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            levelList[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject level in levelList)
        {
            level.SetActive(false);
        }

        //toggle the first index
        if (levelList[0])
        {
            levelList[0].SetActive(true);
            changeText(0);
        }
	}
	
    private void changeText(int index)
    {
        nameText.text = levelSO[index].levelName;
        abstractText.text = levelSO[index].levelStory;
    }

    public void moveLeft()
    {
        //toggle off the current model
        levelList[index].SetActive(false);

        if (--index < 0)
            index = levelList.Length - 1;

        //toggle on the new model
        levelList[index].SetActive(true);
        changeText(index);
    }

    public void moveRight()
    {
        //toggle off the current model
        levelList[index].SetActive(false);

        if (++index == levelList.Length)
            index = 0;

        //toggle on the new model
        levelList[index].SetActive(true);
        changeText(index);
    }

    public void LoadScene()
    {
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene() //May need to use a static class
    {
        AsyncOperation result = SceneManager.LoadSceneAsync(levelSO[index].levelScene.sceneID);

        //Wait until the last operation fully loads to return anything
        while (!result.isDone)
        {
            Debug.Log(result.progress);
            yield return null;
        }
    }
}
