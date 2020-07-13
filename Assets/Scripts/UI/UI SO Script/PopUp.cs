using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UI/Popup")]
public class PopUp : ScriptableObject {

    public GameObject prefab;
    public LayerMask layerMask;
    public Color GlowColor;
}
