using UnityEngine;
using System.Collections;

namespace UnforeseenConsequences
{
	public class InteractiveObject : MonoBehaviour
	{
		protected static DraggableItem m_draggedItem;

		public virtual void destroyObject()
		{
			this.gameObject.SetActive(false);
			Destroy(this);
		}

		public virtual void handleMouseDown()
		{
		}

		public virtual void handleMouseUp()
		{
		}
	}
}
