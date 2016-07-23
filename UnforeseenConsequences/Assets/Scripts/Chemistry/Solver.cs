using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace UnforeseenConsequences.Chemistry
{
	public static class Solver
	{
		private static Reaction[] allReactions;

		public static List<Substance> Solve(IEnumerable<Substance> substances)
		{
			EnsureReactions();
			List<Substance> pool = new List<Substance>(substances);

			// Invoke reactions until nothing reacts anymore
			while (InvokeReaction(pool));

			// Return the remaining (or created) substances
			return pool;
		}
		private static bool InvokeReaction(List<Substance> substances)
		{
			foreach (Reaction reaction in allReactions)
			{
				// Skip if not all required substances are there
				if (!reaction.RequiredSubstances.All(required => substances.Contains(required)))
					continue;

				// Remove the required substances
				foreach (Substance required in reaction.RequiredSubstances)
				{
					substances.Remove(required);
				}

				// Trigger the reaction's effect and add any created substances into the mix
				if (reaction.EffectWhenMixed != null)
					reaction.EffectWhenMixed.Trigger();
				substances.Add(reaction.CreatedSubstance);

				// Stop after one invoked reaction
				return true;
			}

			return false;
		}
		private static void EnsureReactions()
		{
			if (allReactions != null) return;
			allReactions = UnityEngine.Object.FindObjectsOfType<Reaction>();
		}
	}
}
