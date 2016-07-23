using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace UnforeseenConsequences.Chemistry
{
	[Serializable]
	[CreateAssetMenu]
	public class ScaleEffect : Effect
	{
		[SerializeField] private float scaleBy;

		public override void Trigger(Character applyTo)
		{
			base.Trigger(applyTo);
			if (applyTo != null)
			{
				applyTo.transform.localScale *= this.scaleBy;
			}
		}
	}
}
