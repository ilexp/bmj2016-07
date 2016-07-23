using UnityEngine;
using System.Collections;

public class Item : InteractiveObject
{
	bool m_isCarried = false;
	bool m_isBeingDragged = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//checkForMouseClick();
        if (m_isBeingDragged)
		{
			Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (transform.position != worldMousePos)
			{
				Debug.Log("local pos = " + transform.position + ", mouse position = " + Input.mousePosition + ", world mouse pos = " + worldMousePos);
				transform.position = new Vector3(worldMousePos.x, worldMousePos.y, -1);
			}
		}
	}

	public override void simpleUseObject()
	{
		if (m_isCarried)
		{
			startDraggingItem();
		}
		else
		{
			Debug.Log("attempt to pick up " + this.gameObject.name);
			//if (m_playerInventory)
			//{
			//	m_playerInventory.pickupItem(this);
			//	m_isCarried = true;
			//}
		}
	}

	public void startDraggingItem()
	{
		//if (m_playerInventory)
		//{
		//	m_playerInventory.prepareItemUse(this);
		//}

		m_isBeingDragged = true;
		BoxCollider2D coll = this.GetComponent<BoxCollider2D>();
		if (coll)
		{
			coll.enabled = false;
		}
	}

	public void stopDraggingItem(bool in_reenableCollider)
	{
		m_isBeingDragged = false;
		if (in_reenableCollider)
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
		m_isBeingDragged = false;
		base.destroyObject();
	}

}
