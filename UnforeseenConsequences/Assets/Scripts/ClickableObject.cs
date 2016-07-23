using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour
{
	bool m_isHovered = false;

	public void OnMouseEnter()
	{
		m_isHovered = true;
		//Debug.Log("OnMouseEnter event on " + this.gameObject.name);
	}

	public void OnMouseExit()
	{
		m_isHovered = false;
		//Debug.Log("OnMouseExit event on " + this.gameObject.name);
	}

	void Update()
	{
		checkForMouseClick();
	}

	protected void checkForMouseClick()
	{
		if (m_isHovered && !EventSystem.current.IsPointerOverGameObject())
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				Debug.Log("Left Mouse click event on " + this.gameObject.name);
				handleLeftMouseClick(Input.mousePosition);
			}
		}
	}

	protected void releaseDraggedItem()
	{
		//if (m_playerInventory)
		//{
		//	m_playerInventory.releaseDraggedItem();
		//}
	}

	public virtual void handleLeftMouseClick(Vector3 in_mousePos)
	{
		releaseDraggedItem();
		//if (m_player)
		//{
		//	m_player.moveToPosition(in_mousePos, this.gameObject);
		//}
	}
}
