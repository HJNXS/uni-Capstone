using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using levelOrganisation;

/// <summary>
/// LevelLists is a scriptable object used as a container
///  of scenes by scene manage to switch between scene.
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>01/08/18</LastEdited>
[System.Obsolete("Not using anymore, using simple list in SceneManage", true)]
[CreateAssetMenu(fileName = "New Scene List", menuName = "LevelOrganisation/New Scene List")]
public class LevelLists : ScriptableObject {

	public int index;

    public List<CustomScene> levels = new List<CustomScene>();
}
