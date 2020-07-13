using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stealing Combination/Create New List")]
public class CombinationElementList : ScriptableObject {
    public List<CombinationElement> comboList = new List<CombinationElement>();
}
