using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace UnforeseenConsequences.Chemistry
{
	[Serializable]
	[CreateAssetMenu]
	public class MixFeedbackEffect : Effect
	{
		public override void Trigger()
		{
			Debug.Log("Mixing Feedback");
		}
	}
}
