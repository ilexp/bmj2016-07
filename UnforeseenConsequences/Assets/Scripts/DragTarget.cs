using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnforeseenConsequences.Chemistry;

namespace UnforeseenConsequences
{
	public class DragTarget : InteractiveObject
	{
		public static DragTarget m_hoveredObject = null;

		public void OnMouseEnter()
		{
			m_hoveredObject = this;
			Debug.Log("OnMouseEnter event on " + this.gameObject.name);
		}

		public void OnMouseExit()
		{
			// assumes there's no overlap
			m_hoveredObject = null;
			Debug.Log("OnMouseExit event on " + this.gameObject.name);
		}

		public void interactWithObject(DraggableItem in_item)
		{
			if (in_item)
			{
				Debug.Log("attempt to interact with " + this.gameObject.name + (in_item == null ? "" : " while dragging " + in_item.name));
				MixingPot potScript = GetComponent<MixingPot>();
				if (potScript)
				{
					potScript.addPotion(in_item);
				}
				in_item.destroyObject();
			}
		}
	}
}
