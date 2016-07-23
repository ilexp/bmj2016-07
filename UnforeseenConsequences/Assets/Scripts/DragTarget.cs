using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnforeseenConsequences.Chemistry;

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
			BottlePotionOnClick potScript = GetComponent<BottlePotionOnClick>();
			if (potScript)
			{
				potScript.addPotion(in_item);
			}
			in_item.destroyObject();
		}
	}
}
