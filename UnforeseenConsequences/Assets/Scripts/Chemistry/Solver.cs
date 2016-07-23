using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace UnforeseenConsequences.Chemistry
{
	public static class Solver
	{
		public static List<Substance> Solve(IEnumerable<Substance> substances)
		{
			EnsureReactions();
			List<Substance> pool = new List<Substance>(substances);
			bool multiple = pool.Count > 1;

			// Invoke reactions until nothing reacts anymore
			while (InvokeReaction(pool));

			// Are there substances left with no reaction performed? Explode!
			if (multiple && pool.Count > 0)
			{
				Reactions.ExplodeEffect.Trigger();
				pool.Clear();
			}

			// Return the remaining (or created) substances
			return pool;
		}
		private static bool InvokeReaction(List<Substance> substances)
		{
			foreach (Reaction reaction in Reactions.All)
			{
				// Skip if not all required substances are there
				if (!reaction.Ingredients.All(required => substances.Contains(required)))
					continue;

				// Remove the required substances
				foreach (Substance required in reaction.Ingredients)
				{
					substances.Remove(required);
				}

				// Trigger the reaction's effect and add any created substances into the mix
				if (reaction.EffectWhenMixed != null)
					reaction.EffectWhenMixed.Trigger();
				substances.Add(reaction.Result);

				// Stop after one invoked reaction
				return true;
			}

			return false;
		}
		private static void EnsureReactions()
		{
			if (Reactions.Initialized) return;
			Reactions.Init();
		}
	}
}
