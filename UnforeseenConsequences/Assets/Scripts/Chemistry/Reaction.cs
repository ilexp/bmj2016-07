using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace UnforeseenConsequences.Chemistry
{
	public struct Reaction
	{
		private Substance[] ingredients;
		private Effect effectWhenMixed;
		private Substance result;

		public IEnumerable<Substance> Ingredients
		{
			get { return this.ingredients; }
		}
		public Substance Result
		{
			get { return this.result; }
		}
		public Effect EffectWhenMixed
		{
			get { return this.effectWhenMixed; }
		}

		public Reaction(Substance first, Substance second, Substance result, Effect mixEffect)
		{
			Debug.LogFormat("Created Reaction {0}, {1}, {2}, {3}", first, second, result, mixEffect);
			this.ingredients = new Substance[2];
			this.ingredients[0] = first;
			this.ingredients[1] = second;
			this.result = result;
			this.effectWhenMixed = mixEffect;
		}
	}
}
