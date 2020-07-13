using UnityEditor;
using UnityEngine;
using HardlightAnvil.RunWithIt.Actions;

[CustomEditor(typeof(RenderThrowArc))]
public class ThrowArc : Editor {
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUI.enabled = Application.isPlaying;

        RenderThrowArc e = target as RenderThrowArc;
        e.RenderArc();
    }
}
