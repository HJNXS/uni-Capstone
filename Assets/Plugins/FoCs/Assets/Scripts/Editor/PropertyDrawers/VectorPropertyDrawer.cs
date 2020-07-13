using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor.PropertyDrawers
{
	public class VectorPropEditor: FoCsPropertyDrawer
	{
		protected const        float      LABEL_WIDTH = 16;
		public static readonly GUIContent X_Content   = new GUIContent("X", "The X Value Of this Vector");
		public static readonly GUIContent Y_Content   = new GUIContent("Y", "The Y Value Of this Vector");
		public static readonly GUIContent Z_Content   = new GUIContent("Z", "The Z Value Of this Vector");
		public static readonly GUIContent W_Content   = new GUIContent("W", "The W Value Of this Vector");
	}

	[CustomPropertyDrawer(typeof(Vector2))]
	public class Vector2PropEditor: VectorPropEditor
	{
		public override void OnGUI(Rect                            position, SerializedProperty property, GUIContent label)
		{
			Draw(position, property, label);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent         label)
		{
			return SingleLine;
		}

		public static void Draw(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var propScope = FoCsEditor.Disposables.PropertyScope(position, label, property))
			{
				label           = propScope.content;
				position.height = SingleLine;

				if(string.IsNullOrEmpty(label.text))
					DoFieldsDraw(position, property);
				else
				{
					EditorGUI.LabelField(position, label);

					using(FoCsEditor.Disposables.IndentSet(0))
					{
						var pos = position.Edit(RectEdit.AddX(EditorGUIUtility.labelWidth), RectEdit.SubtractWidth(EditorGUIUtility.labelWidth));
						DoFieldsDraw(pos, property);
					}
				}
			}
		}

		private static void DoFieldsDraw(Rect position, SerializedProperty property)
		{
			using(FoCsEditor.Disposables.LabelSetWidth(LABEL_WIDTH))
			{
				using(var scope = FoCsEditor.Disposables.RectHorizontalScope(2, position))
				{
					property.Next(true);
					EditorGUI.PropertyField(scope.GetNext(RectEdit.AddY(1), RectEdit.SubtractHeight(1), RectEdit.SubtractWidth(2)), property, X_Content);
					property.Next(true);
					EditorGUI.PropertyField(scope.GetNext(RectEdit.AddY(1), RectEdit.SubtractHeight(1)), property, Y_Content);
				}
			}
		}
	}

	[CustomPropertyDrawer(typeof(Vector3))]
	public class Vector3PropEditor: VectorPropEditor
	{
		public override void OnGUI(Rect                            position, SerializedProperty property, GUIContent label)
		{
			Draw(position, property, label);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent         label)
		{
			return SingleLine;
		}

		public static void Draw(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var propScope = FoCsEditor.Disposables.PropertyScope(position, label, property))
			{
				label           = propScope.content;
				position.height = SingleLine;

				if(string.IsNullOrEmpty(label.text))
					DoFieldsDraw(position, property);
				else
				{
					EditorGUI.LabelField(position, label);

					using(FoCsEditor.Disposables.IndentSet(0))
					{
						var pos = position.Edit(RectEdit.AddX(EditorGUIUtility.labelWidth), RectEdit.SubtractWidth(EditorGUIUtility.labelWidth));
						DoFieldsDraw(pos, property);
					}
				}
			}
		}

		private static void DoFieldsDraw(Rect position, SerializedProperty property)
		{
			using(FoCsEditor.Disposables.LabelSetWidth(LABEL_WIDTH))
			{
				using(var scope = FoCsEditor.Disposables.RectHorizontalScope(3, position))
				{
					property.Next(true);
					EditorGUI.PropertyField(scope.GetNext(RectEdit.AddY(1), RectEdit.SubtractHeight(1), RectEdit.SubtractWidth(2)), property, X_Content);
					property.Next(true);
					EditorGUI.PropertyField(scope.GetNext(RectEdit.AddY(1), RectEdit.SubtractHeight(1), RectEdit.SubtractWidth(2)), property, Y_Content);
					property.Next(true);
					EditorGUI.PropertyField(scope.GetNext(RectEdit.AddY(1), RectEdit.SubtractHeight(1)), property, Z_Content);
				}
			}
		}
	}

	[CustomPropertyDrawer(typeof(Vector4))]
	public class Vector4PropEditor: VectorPropEditor
	{
		public override void OnGUI(Rect                            position, SerializedProperty property, GUIContent label)
		{
			Draw(position, property, label);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent         label)
		{
			return SingleLine;
		}

		public static void Draw(Rect position, SerializedProperty property, GUIContent label)
		{
			using(var propScope = FoCsEditor.Disposables.PropertyScope(position, label, property))
			{
				label           = propScope.content;
				position.height = SingleLine;

				if(string.IsNullOrEmpty(label.text))
					DoFieldsDraw(position, property);
				else
				{
					EditorGUI.LabelField(position, label);

					using(FoCsEditor.Disposables.IndentSet(0))
					{
						var pos = position.Edit(RectEdit.AddX(EditorGUIUtility.labelWidth), RectEdit.SubtractWidth(EditorGUIUtility.labelWidth));
						DoFieldsDraw(pos, property);
					}
				}
			}
		}

		private static void DoFieldsDraw(Rect position, SerializedProperty property)
		{
			using(FoCsEditor.Disposables.LabelSetWidth(LABEL_WIDTH))
			{
				using(var scope = FoCsEditor.Disposables.RectHorizontalScope(4, position))
				{
					property.Next(true);
					EditorGUI.PropertyField(scope.GetNext(RectEdit.AddY(1), RectEdit.SubtractHeight(1), RectEdit.SubtractWidth(2)), property, X_Content);
					property.Next(true);
					EditorGUI.PropertyField(scope.GetNext(RectEdit.AddY(1), RectEdit.SubtractHeight(1), RectEdit.SubtractWidth(2)), property, Y_Content);
					property.Next(true);
					EditorGUI.PropertyField(scope.GetNext(RectEdit.AddY(1), RectEdit.SubtractHeight(1), RectEdit.SubtractWidth(2)), property, Z_Content);
					property.Next(true);
					EditorGUI.PropertyField(scope.GetNext(RectEdit.AddY(1), RectEdit.SubtractHeight(1)), property, W_Content);
				}
			}
		}
	}

	[CustomPropertyDrawer(typeof(Quaternion))] public class QuaternionPropEditor: Vector4PropEditor { }
}