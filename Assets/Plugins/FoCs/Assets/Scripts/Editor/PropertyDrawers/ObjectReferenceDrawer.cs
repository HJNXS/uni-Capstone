﻿using System.Collections.Generic;
using ForestOfChaosLib.Editor.Utilities;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers
{
	public class ObjectReferenceDrawer: FoCsPropertyDrawer
	{
		protected static readonly GUIContent       foldoutGUIContent = new GUIContent("", "Open up the References Data");
		protected                 bool             foldout;
		protected                 SerializedObject serializedObject;

		protected virtual bool AllowFoldout
		{
			get { return true; }
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var propScope = FoCsEditor.Disposables.PropertyScope(position,label,property))
			{
				label = propScope.content;

				using(var changeCheckScope = FoCsEditor.Disposables.ChangeCheck())
				{
					FoCsGUI.PropertyField(position.Edit(RectEdit.SetHeight(SingleLine),RectEdit.ChangeY(1)),property,label);

					if(changeCheckScope.changed && (property.objectReferenceValue != null))
					{
						property.serializedObject.ApplyModifiedProperties();
						serializedObject = new SerializedObject(property.objectReferenceValue);
					}
				}
			}

			if(property.objectReferenceValue == null || !AllowFoldout)
			{
				serializedObject = null;

				return;
			}

			if(serializedObject == null)
				serializedObject = new SerializedObject(property.objectReferenceValue);

			foldout = DrawReference(position, serializedObject, foldout);
		}

		public static bool DrawReference(Rect position ,SerializedObject serializedObject, bool foldout)
		{
			if(serializedObject.VisibleProperties() == 0)
				return false;

			var iterator = serializedObject.GetIterator();
			iterator.Next(true);
			foldout = EditorGUI.Foldout(position.Edit(RectEdit.SetHeight(SingleLine),RectEdit.SetWidth(SingleLine),RectEdit.ChangeY(1)),foldout,foldoutGUIContent);

			if(!foldout)
				return false;

			DrawSurroundingBox(position);

			using(var changeCheckScope = FoCsEditor.Disposables.ChangeCheck())
			{
				using(FoCsEditor.Disposables.Indent())
				{
					var drawPos = position.Edit(RectEdit.AddY(SingleLinePlusPadding),RectEdit.SubtractHeight(SingleLinePlusPadding),RectEdit.ChangeY(1));

					do
					{
						if(!FoCsEditor.IsPropertyHidden(iterator))
							drawPos = DrawSubProp(iterator,drawPos);
					}
					while(iterator.NextVisible(false));

					if(changeCheckScope.changed)
						serializedObject.ApplyModifiedProperties();
				}
			}

			return true;
		}

		protected static void DrawSurroundingBox(Rect position)
		{
			if(Event.current.type == EventType.Repaint)
				GUI.skin.box.Draw(position.Edit(RectEdit.ChangeY(-1), RectEdit.AddWidth(2)), false, false, false, false);
		}

		protected static Rect DrawSubProp(SerializedProperty prop, Rect drawPos)
		{
			var height = FoCsGUI.GetPropertyHeight(prop, FoCsGUI.AttributeCheck.DoCheck);
			drawPos.height = height;
			FoCsGUI.PropertyField(drawPos, prop, prop.isExpanded, FoCsGUI.AttributeCheck.DoCheck);
			drawPos.y += height + Padding;

			return drawPos;
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return PropertyHeight(serializedObject, foldout);
		}

		public static float PropertyHeight(SerializedObject serializedObject, bool foldout)
		{
			if((serializedObject == null) || !foldout || (serializedObject.VisibleProperties() == 0))
				return SingleLine + 1;

			var iterator = serializedObject.GetIterator();
			iterator.Next(true);
			iterator.Next(true);
			var height = 1f;

			do
			{
				if(!FoCsEditor.IsPropertyHidden(iterator))
					height += FoCsGUI.GetPropertyHeight(iterator, iterator.isExpanded, FoCsGUI.AttributeCheck.DoCheck) + Padding;
			}
			while(iterator.NextVisible(false));

			return height;
		}

#region Storage
		private static readonly Dictionary<string, ObjectReferenceDrawer> objectDrawers = new Dictionary<string, ObjectReferenceDrawer>(10);

		public static ObjectReferenceDrawer GetObjectDrawer(SerializedProperty property)
		{
			var                   id = string.Format("{0}:{1}-{2}", property.serializedObject.targetObject.name, property.propertyPath, property.name);
			ObjectReferenceDrawer objDraw;

			if(objectDrawers.TryGetValue(id, out objDraw))
				return objDraw;

			objDraw = new ObjectReferenceDrawer();
			objectDrawers.Add(id, objDraw);

			return objDraw;
		}
#endregion
	}
}
