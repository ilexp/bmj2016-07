using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace UnforeseenConsequences.Chemistry
{
	[Serializable]
	[CreateAssetMenu]
	public class ExplodeEffect : Effect
	{
		public override void Trigger()
		{
			Debug.Log("EXPLODE");
		}
	}
}
