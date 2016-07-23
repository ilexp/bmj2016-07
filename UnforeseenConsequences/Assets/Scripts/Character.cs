using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

using UnforeseenConsequences.Chemistry;

namespace UnforeseenConsequences
{
	public class Character : MonoBehaviour, IDragTargetListener
	{
		public void OnItemDragged(DraggableItem in_item)
		{
			Potion potionScript = in_item.GetComponent<Potion>();
			if (potionScript.Content.EffectWhenApplied != null)
				potionScript.Content.EffectWhenApplied.Trigger(this);
		}
	}
}
