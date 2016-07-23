using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace UnforeseenConsequences.Chemistry
{
	[Serializable]
	[CreateAssetMenu]
	public class Reaction : ScriptableObject
	{
		[SerializeField] private Substance[] requiredSubstances;
		[SerializeField] private Effect effect = new CreateSubstanceEffect();

		public IEnumerable<Substance> RequiredSubstances
		{
			get { return this.requiredSubstances; }
		}
		public Effect Effect
		{
			get { return this.effect; }
		}
	}
}
