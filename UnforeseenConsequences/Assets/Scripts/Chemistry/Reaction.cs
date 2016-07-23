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
		[SerializeField] private Substance[] requiredSubstances = new Substance[2];
		[SerializeField] private Effect effectWhenMixed;
		[SerializeField] private Substance createdSubstance;

		public IEnumerable<Substance> RequiredSubstances
		{
			get { return this.requiredSubstances; }
		}
		public Substance CreatedSubstance
		{
			get { return this.createdSubstance; }
		}
		public Effect EffectWhenMixed
		{
			get { return this.effectWhenMixed; }
		}
	}
}
