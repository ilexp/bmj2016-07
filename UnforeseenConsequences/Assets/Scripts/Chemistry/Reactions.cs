using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace UnforeseenConsequences.Chemistry
{
	public static class Reactions
	{
		private static Reaction[] all;
		public static IEnumerable<Reaction> All
		{
			get { return all; }
		}
		public static bool Initialized
		{
			get { return all != null; }
		}

		public static void Init()
		{
			all = new Reaction[]
			{
				Create("Fire", "Water", "Steam", "MixSuccessFeedback")
			};
		}
		private static Reaction Create(string first, string second, string result, string mixEffect)
		{
			Effect[] effects = UnityEngine.Object.FindObjectsOfType<Effect>();
			Substance[] substances = UnityEngine.Object.FindObjectsOfType<Substance>();
			return new Reaction(
				substances.FirstOrDefault(s => s.name == first),
				substances.FirstOrDefault(s => s.name == second),
				substances.FirstOrDefault(s => s.name == result),
				effects.FirstOrDefault(s => s.name == mixEffect));
		}
	}
}
