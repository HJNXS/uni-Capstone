using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEngine;

namespace ForestOfChaosLib.Editor
{
	// ReSharper disable once MismatchedFileName
	public partial class FoCsGUI
	{
		public static partial class Styles
		{
			private static GUIStyle downArrow;

			public static GUIStyle DownArrow
			{
				get
				{
					if(downArrow != null)
						return downArrow;

					downArrow = new GUIStyle("RL FooterButton") {normal = new GUIStyleState {background = GetTexture("FoCs_d_1_arrow")}, name = "DownArrow"};

					return downArrow;
				}
			}

			private static GUIStyle down2Arrow;

			public static GUIStyle Down2Arrow
			{
				get
				{
					if(down2Arrow != null)
						return down2Arrow;

					down2Arrow = new GUIStyle("RL FooterButton") {normal = new GUIStyleState {background = GetTexture("FoCs_d_2_arrow")}, name = "Down2Arrow"};

					return down2Arrow;
				}
			}

			private static GUIStyle upArrow;

			public static GUIStyle UpArrow
			{
				get
				{
					if(upArrow != null)
						return upArrow;

					upArrow = new GUIStyle("RL FooterButton") {normal = new GUIStyleState {background = GetTexture("FoCs_u_1_arrow")}, name = "UpArrow"};

					return upArrow;
				}
			}

			private static GUIStyle up2Arrow;

			public static GUIStyle Up2Arrow
			{
				get
				{
					if(up2Arrow != null)
						return up2Arrow;

					up2Arrow = new GUIStyle("RL FooterButton") {normal = new GUIStyleState {background = GetTexture("FoCs_u_2_arrow")}, name = "Up2Arrow"};

					return up2Arrow;
				}
			}

			private static GUIStyle inLineOptionsMenu;

			public static GUIStyle InLineOptionsMenu
			{
				get
				{
					if(inLineOptionsMenu != null)
						return inLineOptionsMenu;

					inLineOptionsMenu = new GUIStyle("Icon.TrackOptions") {overflow = {top = -4, bottom = 4}, name = "InLineOptionsMenu"};

					return inLineOptionsMenu;
				}
			}

			private static GUIStyle buttonNoOutline;

			public static GUIStyle ButtonNoOutline
			{
				get
				{
					if(buttonNoOutline != null)
						return buttonNoOutline;

					buttonNoOutline = new GUIStyle(GUI.skin.button) {normal = {background = null}, active = {background = null}, focused = {background = null}, hover = {background = null}, name = "ButtonNoOutline"};

					return buttonNoOutline;
				}
			}

			private static GUIStyle crossCircle;

			public static GUIStyle CrossCircle
			{
				get
				{
					if(crossCircle != null)
						return crossCircle;

					crossCircle = new GUIStyle("TL SelectionBarCloseButton")
					{
							fixedHeight = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing,
							fixedWidth  = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing,
							name        = "CrossCircle"
					};

					return crossCircle;
				}
			}

			private static GUIStyle toolbar;

			public static GUIStyle Toolbar
			{
				get
				{
					if(toolbar != null)
						return toolbar;

					toolbar = new GUIStyle(Unity.Toolbar) {fixedHeight = 0, name = "Toolbar"};

					return toolbar;
				}
			}

			private static GUIStyle toolbarButton;

			public static GUIStyle ToolbarButton
			{
				get
				{
					if(toolbarButton != null)
						return toolbarButton;

					toolbarButton = new GUIStyle(Unity.ToolbarButton) {fixedHeight = 0, name = "ToolbarButton"};

					return toolbarButton;
				}
			}

			private static GUIStyle find;

			public static GUIStyle Find
			{
				get
				{
					if(find != null)
						return find;

					find = new GUIStyle("RL FooterButton") {normal = {background = GetTexture("FoCs_find")}, hover = {background = GetTexture("FoCs_find_hover")}, active = {background = GetTexture("FoCs_find_active")}, name = "Find"};

					return find;
				}
			}

			private const float RowField_ALPHA = 0.6f;
			private static GUIStyle rowField;

			public static GUIStyle RowField
			{
				get
				{
					if(rowField != null)
						return rowField;

					rowField = new GUIStyle("Button") {name = "RowField",};
					rowField.margin = new RectOffset(0, 0, 0, 0);

					rowField.normal.textColor   = Color.white;
					rowField.onNormal.textColor = Color.white;

					rowField.normal.background = TextureUtilities.GetSolidTexture(new Color(0.6f, 0.6f, 0.6f, RowField_ALPHA));
					rowField.onNormal.background = TextureUtilities.GetSolidTexture(new Color(0.7f, 0.7f, 0.7f, RowField_ALPHA));

					rowField.hover.textColor = Color.white;
					rowField.onHover.textColor = Color.white;

					rowField.hover.background   = TextureUtilities.GetSolidTexture(new Color(0.9f, 0.4f, 0f, RowField_ALPHA));
					rowField.onHover.background = TextureUtilities.GetSolidTexture(new Color(1f, 0.5f, 0f, RowField_ALPHA));

					rowField.active.textColor = Color.white;
					rowField.onActive.textColor = Color.white;

					rowField.active.background   = TextureUtilities.GetSolidTexture(new Color(0.4f, 0.9f, 0.4f, RowField_ALPHA));
					rowField.onActive.background = TextureUtilities.GetSolidTexture(new Color(0.5f, 1f, 0.5f, RowField_ALPHA));

					rowField.onFocused.textColor = Color.white;
					rowField.onFocused.background = TextureUtilities.GetSolidTexture(new Color(0.17f, 0f, 0.69f, RowField_ALPHA));

					return rowField;
				}
			}
			private static GUIStyle rowOddField;

			public static GUIStyle RowOddField
			{
				get
				{
					if(rowOddField != null)
						return rowOddField;

					rowOddField = new GUIStyle(RowField){
							name   = "RowOddField"
					};

					rowField.normal.background   = TextureUtilities.GetSolidTexture(new Color(0.5f, 0.51f, 0.51f, 1));

					return rowOddField;
				}
			}
		}
	}
}
