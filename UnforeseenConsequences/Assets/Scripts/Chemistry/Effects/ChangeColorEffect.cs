using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using UnityEngine.UI;

namespace UnforeseenConsequences.Chemistry
{
	[Serializable]
	[CreateAssetMenu]
	public class ChangeColorEffect : Effect
	{
		[SerializeField] private Color color;

		public override void Trigger(Character applyTo)
		{
			base.Trigger(applyTo);
			if (applyTo != null)
			{
				Image gfx = applyTo.GetComponent<Image>();
				if (gfx != null)
					gfx.color = this.color;
			}
		}
	}
}
