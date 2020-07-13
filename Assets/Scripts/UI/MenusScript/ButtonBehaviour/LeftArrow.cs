using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftArrow : MonoBehaviour, IMoveHandler
{

    public LevelSelection select;

    public void OnMove(AxisEventData eventData)
    {
        if (eventData.moveDir == MoveDirection.Left)
            select.moveLeft();
    }
}
