using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using levelOrganisation;

[CreateAssetMenu(menuName = "UI/Level")]
public class Level : ScriptableObject {

    public string levelName;    
    public string levelStory;
    public LevelScene levelScene;
}
