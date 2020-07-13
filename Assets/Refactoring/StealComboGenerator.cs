using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StealComboGenerator : MonoBehaviour{

    public int maxComboSize = 8;
    private float imageSize;
    private Queue<CombinationElement> comboPool = new Queue<CombinationElement>();
    public CombinationElementList allCombinations;
    private Canvas bb;
    private Transform camTransform;
    private bool generated = false;
    public bool redraw = false;

    public Queue<CombinationElement> ComboPool
    {
        get
        {
            return comboPool;
        }

        set
        {
            comboPool = value;
        }
    }

    private void Awake()
    {
        //camTransform = Camera.main.transform;
        bb = GetComponentInChildren<Canvas>();
    }

    public void Execute(GameObject e)
    {
        Perform();
        Display();
    }


    //Generates the combination we have to complete
    private bool Perform()
    {
        if (allCombinations.comboList.Count <= 0)
            return false;

        while (ComboPool.Count < maxComboSize)
        {
            for (int i = 0; i < maxComboSize; i++)
                ComboPool.Enqueue(allCombinations.comboList[Random.Range(0, allCombinations.comboList.Count)]);
            //if generation completed successfully
            
        }
        Debug.Log(ComboPool.Count);
        return true;
    }


    //Displays our generated combination
    private void Display()
    { 
        float i = (float) Screen.width * (float) -0.1;
		imageSize = (float)Screen.height * (float)0.1;
        if (generated && !redraw ) return;
        //Set up UI billboard in local space of object we interacted with
        if(bb)
            foreach (CombinationElement elem in ComboPool)
            {
                GameObject obj = new GameObject();
                RectTransform rect = obj.AddComponent<RectTransform>();
                Image image = obj.AddComponent<Image>();
                image.sprite = elem.sprite;
                rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, imageSize);
                rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, imageSize);
                obj.transform.SetParent(bb.transform, false);
                rect.localPosition = new Vector3(i, 0, 0);
                i += imageSize;
            }

        generated = !generated;
    }

    private void UpdateDisplay()
    {
        for (int i = 0; i < bb.transform.childCount; i++)
            Destroy(bb.transform.GetChild(i).gameObject);
        Display();
        redraw = !redraw;
    }

    private void LateUpdate()
    {
        if (bb)
        {
            //uncomment if camera implemented
            //bb.transform.LookAt(camTransform);
            //bb.transform.rotation = Quaternion.LookRotation(camTransform.forward);
        }
        if (redraw)
            UpdateDisplay();
    }


    //TODO: Create action list that overrides existing inputhandler
}
