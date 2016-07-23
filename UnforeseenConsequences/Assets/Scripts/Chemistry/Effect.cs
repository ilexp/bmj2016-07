using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace UnforeseenConsequences.Chemistry
{
	[Serializable]
	public abstract class Effect : ScriptableObject
	{
		public abstract IEnumerable<Substance> Trigger();
	}
}
