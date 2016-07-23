using UnityEngine;
using System.Collections;

public class InteractiveObject : ClickableObject
{
	[SerializeField]
	private string m_objectId;

	[SerializeField]
	private string m_description;

	[SerializeField]
	Item m_usableItem;

	[SerializeField]
	GameObject m_replacementObject;

	[SerializeField]
	bool m_destroyItemAfterUse;

	public override void handleLeftMouseClick(Vector3 in_mousePos)
	{
		//if (m_player)
		//{
		//	m_player.displayText(m_description);
		//}
	}

	void interactWithObject(Item in_item)
	{
		Debug.Log("attempt to interact with " + this.gameObject.name + (in_item == null ? "" : " while dragging " + in_item.name));
		if (in_item)
		{
			useItemOnObject(in_item);
		}
		else
		{
			simpleUseObject();
		}
	}

	public virtual void simpleUseObject()
	{
	}

	public virtual void useItemOnObject(Item in_item)
	{
		if (in_item == m_usableItem)
		{
			if (m_replacementObject)
			{
				m_replacementObject.SetActive(true);
				this.gameObject.SetActive(false);

				//if (m_destroyItemAfterUse && m_playerInventory)
				//{
				//	m_playerInventory.destroyDraggedItem();
    //            }
			}
		}
	}

	public virtual void destroyObject()
	{
		this.gameObject.SetActive(false);
	}
}
