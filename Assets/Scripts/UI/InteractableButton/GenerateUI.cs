using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Instantiate PopScript to all object define by a given layer.
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>25/08/18</LastEdited>
public class GenerateUI : MonoBehaviour {

    public List<PopUp> popUpsMask;

	void Start () {
        GameObject[] objects = GetSceneObjects();
        GetObjectsInLayer(objects);
    }

    private void GetObjectsInLayer(GameObject[] root)
    {
        foreach (GameObject t in root)
        {
            foreach (PopUp p in popUpsMask)
            {
                if (p.layerMask == (p.layerMask | (1 << t.layer)))
                {
					if (t.GetComponent<PopupScript>() != null)
					{
						t.GetComponent<PopupScript>().setPopUp(p.prefab);
						t.AddComponent<Rigidbody>();
						t.GetComponent<Rigidbody>().isKinematic = true;
					}
				}
            }
        }
    }

	/// <summary>
	/// Get all objects from the scene.
	/// </summary>
	/// <returns>Array of GameObject</returns>
	private GameObject[] GetSceneObjects()
    {
        return Resources.FindObjectsOfTypeAll<GameObject>()
                .Where(go => go.hideFlags == HideFlags.None).ToArray();
    }

}
