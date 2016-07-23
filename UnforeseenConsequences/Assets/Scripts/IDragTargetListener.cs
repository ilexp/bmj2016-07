using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnforeseenConsequences.Chemistry;

namespace UnforeseenConsequences
{
	public interface IDragTargetListener
	{
		void OnItemDragged(DraggableItem in_item);
	}
}
