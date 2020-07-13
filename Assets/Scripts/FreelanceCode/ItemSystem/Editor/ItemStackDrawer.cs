using ForestOfChaosLib.Editor;
using ForestOfChaosLib.Editor.PropertyDrawers;
using ForestOfChaosLib.Extensions;
using ForestOfChaosLib.Utilities;
using UnityEditor;
using UnityEngine;

namespace JMiles42.ItemSystem
{
	[CustomPropertyDrawer(typeof(ItemStack))]
	public class ItemStackDrawer: FoCsPropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var itemProp   = property.FindPropertyRelative("item");
			var amountProp = property.FindPropertyRelative("amount");

			using(var hScope = FoCsEditor.Disposables.RectHorizontalScope(6, position.Edit(RectEdit.SetHeight(SingleLine))))
			{
				using(var propScope = FoCsEditor.Disposables.PropertyScope(position, label, property))
				{
					FoCsGUI.Label(hScope.GetNext(), propScope.content);
					FoCsGUI.PropertyField(hScope.GetNext(3), itemProp, true);
					var rect = hScope.GetNext(2);

					using(FoCsEditor.Disposables.LabelSetWidth(rect.width * 0.6f))
						using(FoCsEditor.Disposables.FieldSetWidth(rect.width * 0.4f))
							FoCsGUI.PropertyField(rect, amountProp);
				}
			}
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return SingleLine;
		}
	}
}