using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragTarget : InteractiveObject
{
	bool m_isHovered = false;
	public static DragTarget m_hoveredObject = null;

	public void OnMouseEnter()
	{
		m_isHovered = true;
		m_hoveredObject = this;
		Debug.Log("OnMouseEnter event on " + this.gameObject.name);
	}

	public void OnMouseExit()
	{
		m_isHovered = false;
		// assumes there's no overlap
		m_hoveredObject = null;
		Debug.Log("OnMouseExit event on " + this.gameObject.name);
	}

	void Update()
	{
		checkForMouseover();
	}

	protected void checkForMouseover()
	{
		if (m_isHovered && !EventSystem.current.IsPointerOverGameObject())
		{
		}
	}

	//public override void handleMouseDown()
	//{
	//	Debug.Log("handleMouseDOWN");
	//}

	//public override void handleMouseUp()
	//{
	//	Debug.Log("handleMouseUP");
	//	if (m_draggedItem != null)
	//	{
	//		interactWithObject(m_draggedItem);
	//	}
	//}

	public void interactWithObject(DraggableItem in_item)
	{
		if (in_item)
		{
			Debug.Log("attempt to interact with " + this.gameObject.name + (in_item == null ? "" : " while dragging " + in_item.name));
			addPotion(in_item);
			in_item.destroyObject();
		}
	}

	void addPotion(DraggableItem i_potion)
	{
		// do stuff
		Debug.Log("added " + i_potion.name + " to pot");
	}
}
