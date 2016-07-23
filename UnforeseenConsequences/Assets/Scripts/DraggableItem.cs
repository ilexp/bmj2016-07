using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnforeseenConsequences.Chemistry;

namespace UnforeseenConsequences
{
	public class DraggableItem : InteractiveObject
	{
		Vector3 m_initialPosition;
		void Start()
		{
			m_initialPosition = transform.position;
		}

		// Update is called once per frame
		void Update()
		{
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
			setImageRaycastTarget(false);
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
				// snap back to initial position
				//transform.position = m_initialPosition;
				setImageRaycastTarget(true);
			}
		}

		void setImageRaycastTarget(bool i_value)
		{
			// enable raycast
			Image[] imageScripts = this.GetComponentsInChildren<Image>();
			foreach (Image img in imageScripts)
			{
				img.raycastTarget = i_value;
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
}