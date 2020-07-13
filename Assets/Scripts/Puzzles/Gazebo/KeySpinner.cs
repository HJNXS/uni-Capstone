using ForestOfChaosLib.Maths;
using UnityEngine;

public class KeySpinner : MonoBehaviour
{
    public Transform Transform;

    public float RotationAmount = 5;

    public float HeightMin = 1;
    public float HeightMax = 1;

    private void Awake()
    {
        if (Transform == null)
            Transform = transform;
    }

    void Update()
    {
        var pos = Transform.position;
        var rot = Transform.eulerAngles;
        var deltaTime = Time.deltaTime;

        pos = new Vector3(pos.x, Mathf.Lerp(HeightMin, HeightMax, (Mathf.Sin(Time.time) + 1) / 2), pos.z);

        rot.y = ((rot.y + RotationAmount)).NormalizeAngle();
        
        Transform.position = pos;
        Transform.eulerAngles = rot;

    }
}
