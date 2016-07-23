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
			List<Substance> pool = new List<Substance>(substances);
			bool multiple = pool.Count > 1;

			// Retrieve the reaction manager
			ReactionManager reactionManager = UnityEngine.Object.FindObjectOfType<ReactionManager>();

			// Invoke reactions until nothing reacts anymore
			bool anyReactionDone = false;
			while (InvokeReaction(reactionManager, pool))
			{
				anyReactionDone = true;
			}

			// Are there substances left with no reaction performed? Explode!
			if (multiple && !anyReactionDone && pool.Count > 0)
			{
				reactionManager.ExplodeEffect.Trigger(null);
				pool.Clear();
			}

			// Return the remaining (or created) substances
			return pool;
		}
		private static bool InvokeReaction(ReactionManager reactionManager, List<Substance> substances)
		{
			if (!reactionManager.Initialized)
				reactionManager.Init();

			foreach (Reaction reaction in reactionManager.Reactions)
			{
				// Skip if not all required substances are there
				bool requirementsMet = true;
				foreach (Substance required in reaction.Ingredients)
				{
					if (!substances.Contains(required))
					{
						requirementsMet = false;
						break;
					}
				}
				if (!requirementsMet)
					continue;

				// Remove the required substances
				foreach (Substance required in reaction.Ingredients)
				{
					substances.Remove(required);
				}

				// Trigger the reaction's effect and add any created substances into the mix
				Debug.LogFormat("Mixed {0} and {1}, got {2}", reaction.Ingredients.ElementAt(0).name, reaction.Ingredients.ElementAt(1).name, reaction.Result.name);
				if (reaction.EffectWhenMixed != null)
					reaction.EffectWhenMixed.Trigger(null);
				substances.Add(reaction.Result);

				// Stop after one invoked reaction
				return true;
			}

			return false;
		}
	}
}
