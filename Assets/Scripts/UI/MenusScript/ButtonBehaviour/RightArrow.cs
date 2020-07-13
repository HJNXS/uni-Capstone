using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightArrow : MonoBehaviour, IMoveHandler
{

    public LevelSelection select;

    public void OnMove(AxisEventData eventData)
    {
        if (eventData.moveDir == MoveDirection.Right)
            select.moveRight();
    }
}
