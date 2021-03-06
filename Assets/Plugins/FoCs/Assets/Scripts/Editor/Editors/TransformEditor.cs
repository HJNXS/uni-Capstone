using System;
using System.Collections.Generic;
using ForestOfChaosLib.Extensions;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	[CustomEditor(typeof(Transform))]
	internal class TransformEditor: FoCsEditor<Transform>
	{
		private static          bool                               scaleToggle;
		private static          float                              scaleAmount       = 1;
		private static readonly GUIContent                         ResetContent      = new GUIContent("Reset Transform",       "Reset Transforms in global space");
		private static readonly GUIContent                         ResetLocalContent = new GUIContent("Reset Local Transform", "Reset Transforms in local space");
		private static          int                                _tabNum;
		private readonly        KeyValuePair<GUIContent, Action>[] TabName;
		public override         bool                               ShowCopyPasteButtons
		{
			get { return true; }
		}

		private static int TabNum
		{
			get { return _tabNum; }
			set { EditorPrefs.SetInt("FoCsTE.TabNum", _tabNum = value); }
		}

		public TransformEditor()
		{
			TabName = new[]
			{
					Pair.Create<GUIContent, Action>(new GUIContent("Hide Extra Options",      "Hides Any Extra Options"),                null),
					Pair.Create<GUIContent, Action>(new GUIContent("Scale Options",           "Scale Preset Options"),                   ScaleButtonsEnabled),
					Pair.Create<GUIContent, Action>(new GUIContent("Global Transform Values", "Force Display of Global Transform Data"), DrawGlobalTransformOptions),
					Pair.Create<GUIContent, Action>(new GUIContent("Local Transform Values",  "Force Display of Local Transform Data"),  DrawLocalTransformOptions)
			};
		}

		public override bool UseDefaultMargins()
		{
			return false;
		}

		protected void OnEnable()
		{
			_tabNum = EditorPrefs.GetInt("FoCsTE.TabNum");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			DoDrawHeader();

			using(Disposables.Indent())
			{
				DrawTransformOptions();

				using(Disposables.HorizontalScope(FoCsGUI.Styles.Toolbar))
				{
					for(var i = 0; i < TabName.Length; i++)
					{
						if(FoCsGUI.Layout.Toggle(TabName[i].Key, TabNum == i, FoCsGUI.Styles.ToolbarButton, GUILayout.Height(16)))
							TabNum = i;
					}
				}

				TabName[TabNum].Value.Trigger();
				serializedObject.ApplyModifiedProperties();
			}
		}

		private void DrawTransformOptions()
		{
			if(Target.parent == null)
				DrawGlobalTransformOptions();
			else
				DrawLocalTransformOptions();
		}

		private void DrawGlobalTransformOptions()
		{
			bool guiChanged;
			var  position = EditorHelpers.DrawVector3("Position", Target.position, Vector3.zero, Target, out guiChanged);

			if(guiChanged)
			{
				Undo.RecordObject(Target, "position Changed");
				Target.position = position;
			}

			var eulerAngles = EditorHelpers.DrawVector3("Rotation", Target.eulerAngles, Vector3.zero, Target, out guiChanged);

			if(guiChanged)
			{
				Undo.RecordObject(Target, "eulerAngles Changed");
				Target.eulerAngles = eulerAngles;
			}

			var scale = EditorHelpers.DrawVector3("Scale", Target.localScale, Vector3.one, Target, out guiChanged);

			if(guiChanged)
			{
				Undo.RecordObject(Target, "scale Changed");
				Target.localScale = scale;
			}
		}

		private void DrawLocalTransformOptions()
		{
			bool guiChanged;
			var  position = EditorHelpers.DrawVector3("Local Position", Target.localPosition, Vector3.zero, Target, out guiChanged);

			if(guiChanged)
			{
				Undo.RecordObject(Target, "position Changed");
				Target.localPosition = position;
			}

			var eulerAngles = EditorHelpers.DrawVector3("Local Rotation", Target.localEulerAngles, Vector3.zero, Target, out guiChanged);

			if(guiChanged)
			{
				Undo.RecordObject(Target, "eulerAngles Changed");
				Target.localEulerAngles = eulerAngles;
			}

			var scale = EditorHelpers.DrawVector3("Local Scale", Target.localScale, Vector3.one, Target, out guiChanged);

			if(guiChanged)
			{
				Undo.RecordObject(Target, "scale Changed");
				Target.localScale = scale;
			}
		}

		protected void DoDrawHeader()
		{
			using(Disposables.HorizontalScope(EditorStyles.toolbar))
			{
				var transform     = Target;
				var resetBtn      = FoCsGUI.Layout.Button(ResetContent,      EditorStyles.toolbarButton);
				var resetLocalBtn = FoCsGUI.Layout.Button(ResetLocalContent, EditorStyles.toolbarButton);

				if(resetBtn)
				{
					Undo.RecordObject(transform, "ResetPosRotScale");
					transform.ResetPosRotScale();
				}

				if(resetLocalBtn)
				{
					Undo.RecordObject(transform, "ResetLocalPosRotScale");
					transform.ResetLocalPosRotScale();
				}

				DrawCopyPasteButtons();
			}
		}

		private void ScaleButtonsEnabled()
		{
			ScaleArea();

			using(Disposables.HorizontalScope(EditorStyles.toolbar))
			{
				SetScaleBtn(0.5f);
				SetScaleBtn(1);
				SetScaleBtn(2);
				SetScaleBtn(5);
				SetScaleBtn(10);
				SetScaleBtn(20);
				SetScaleBtn(50);
				SetScaleBtn(100);
			}

			using(Disposables.HorizontalScope(EditorStyles.toolbar))
			{
				TimesScaleBtn(0.5f);
				TimesScaleBtn(1);
				TimesScaleBtn(2);
				TimesScaleBtn(5);
				TimesScaleBtn(10);
				TimesScaleBtn(20);
				TimesScaleBtn(50);
				TimesScaleBtn(100);
			}
		}

		private void SetScaleBtn(float multi = 1)
		{
			var resetContent = new GUIContent(string.Format("Set: {0}x", multi), string.Format("Sets the Scale to ({0}, {1}, {2})", multi, multi, multi));

			if(GUILayout.Button(resetContent, EditorStyles.toolbarButton))
			{
				var transform = Target;
				Undo.RecordObject(transform, "Scale reset");
				transform.localScale = Vector3.one * multi;
				scaleAmount          = transform.localScale.x;
			}
		}

		private void TimesScaleBtn(float multi = 1)
		{
			var resetContent = new GUIContent(string.Format("Times: {0}x", multi), string.Format("Multiplies the Scale to ({0}, {1}, {2})", Target.localScale.x * multi, Target.localScale.y * multi, Target.localScale.z * multi));

			if(GUILayout.Button(resetContent, EditorStyles.toolbarButton))
			{
				var transform = Target;
				Undo.RecordObject(transform, "Scale reset");
				transform.localScale = transform.localScale * multi;
				scaleAmount          = transform.localScale.x;
			}
		}

		private void ScaleArea()
		{
			var transform = Target;

			using(Disposables.HorizontalScope(EditorStyles.toolbar))
			{
				var content = new GUIContent("Scale amount", "Set amount to uniformly scale the object");
				scaleAmount = EditorGUILayout.FloatField(content, scaleAmount, EditorStyles.toolbarTextField);
				var scaleContent = new GUIContent("Set Scale", string.Format("Sets the scale ({0},{1},{2})", scaleAmount, scaleAmount, scaleAmount));

				if(GUILayout.Button(scaleContent, EditorStyles.toolbarButton))
				{
					Undo.RecordObject(transform, "Scale set");
					transform.localScale = Vector3.one * scaleAmount;
				}

				var scaleTimesContent = new GUIContent("Times Scale", string.Format("Sets the scale ({0},{1},{2})", transform.position.x * scaleAmount, transform.position.y * scaleAmount, transform.position.z * scaleAmount));

				if(GUILayout.Button(scaleTimesContent, EditorStyles.toolbarButton))
				{
					Undo.RecordObject(transform, "Scale set");
					transform.localScale *= scaleAmount;
				}
			}
		}
	}
}
