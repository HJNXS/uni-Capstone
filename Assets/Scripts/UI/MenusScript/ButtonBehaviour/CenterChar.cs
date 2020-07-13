using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CenterChar : MonoBehaviour, ISelectHandler{

    public ScrollSelector scrollCenterScript;
    public RectTransform list;

    public void OnSelect(BaseEventData eventData)
    {
        //if (scrollCenterScript != null)
        //    scrollCenterScript.CenterToItem(transform.GetComponent<RectTransform>());
    }
}
