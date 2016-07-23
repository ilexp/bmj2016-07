using UnityEngine;
using System.Collections;

public class DraggableItem : InteractiveObject
{
	// Update is called once per frame
	void Update ()
	{
		//checkForMouseClick();
        if (this == m_draggedItem)
		{
			Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (transform.position != worldMousePos)
			{
				//Debug.Log("local pos = " + transform.position + ", mouse position = " + Input.mousePosition + ", world mouse pos = " + worldMousePos);
				transform.position = new Vector3(worldMousePos.x, worldMousePos.y, -1);
			}
		}
	}

	public override void handleMouseDown()
	{
		Debug.Log("Start dragging potion");
		m_draggedItem = this;
		BoxCollider2D coll = this.GetComponent<BoxCollider2D>();
		if (coll)
		{
			coll.enabled = false;
		}
	}

	public override void handleMouseUp()
 	{
		Debug.Log("Stop dragging potion");
		m_draggedItem = null;
		if (DragTarget.m_hoveredObject)
		{
			DragTarget.m_hoveredObject.interactWithObject(this);
		}
		else
		{
			BoxCollider2D coll = this.GetComponent<BoxCollider2D>();
			if (coll)
			{
				coll.enabled = true;
			}
		}
	}

	public override void destroyObject()
	{
		if (this == m_draggedItem)
		{
			m_draggedItem = null;
		}
		base.destroyObject();
	}

}
