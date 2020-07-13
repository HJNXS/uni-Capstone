using UnityEngine;

public class UIFollowTransform : MonoBehaviour
{
    public RectTransform self;
    public Transform transformToFollow;

    public Vector3 Offset;

    private void Start()
    {
        if(self == null)
            self = GetComponent<RectTransform>();
    }

    public void Update()
    {
        var screenPoint = Camera.main.WorldToScreenPoint(transformToFollow.position + Offset);
        self.position = screenPoint;
    }
}
