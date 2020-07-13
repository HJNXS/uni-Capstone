/*
* Author: Daniel Newman
* Last Edited: 24/05/18
* Summary: Editor extension to facilitate testing of 
* GameEvent & GameEventListener functionality
*/



using UnityEditor;
using UnityEngine;


namespace HardlightAnvil.RunWithIt.Events
{
    [CustomEditor(typeof(GameEvent))]
    public class EventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUI.enabled = Application.isPlaying;

            GameEvent e = target as GameEvent;
            if (GUILayout.Button("Invoke"))
                e.Invoke();
        }
       
    }
}