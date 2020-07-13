using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ComboItems { Up, Down, Left, Right, A, B, X, Y, LB, LT, RB, RT}



[CreateAssetMenu(menuName = "Stealing Combination/Create New Element")]
public class CombinationElement : ScriptableObject {

    public Sprite sprite;
    public ComboItems inputComparitor;

}
