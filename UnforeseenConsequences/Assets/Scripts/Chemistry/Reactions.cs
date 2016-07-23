﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace UnforeseenConsequences.Chemistry
{
	public static class Reactions
	{
		private static Reaction[] all;
		private static Effect explodeEffect;

		public static IEnumerable<Reaction> All
		{
			get { return all; }
		}
		public static Effect ExplodeEffect
		{
			get { return explodeEffect; }
		}
		public static bool Initialized
		{
			get { return all != null; }
		}

		public static void Init()
		{
			Effect[] effects = UnityEngine.Object.FindObjectsOfType<Effect>();
			explodeEffect = effects.FirstOrDefault(s => s.name == "Explosion");
			all = new Reaction[]
			{
				Create("Fire", "Water", "Steam", "MixSuccessFeedback"),
				Create("Fire", "Air", "Lightning", "MixSuccessFeedback"),
				Create("Fire", "Earth", "Magma", "MixSuccessFeedback"),
				Create("Water", "Air", "Ghost", "MixSuccessFeedback"),
				Create("Water", "Earth", "Plant", "MixSuccessFeedback"),
				Create("Air", "Earth", "Dust", "MixSuccessFeedback"),
				Create("Steam", "Earth", "Gas", "MixSuccessFeedback"),
				Create("Ghost", "Fire", "Demon", "MixSuccessFeedback"),
				Create("Ghost", "Earth", "Live", "MixSuccessFeedback"),
				Create("Magma", "Water", "Stone", "MixSuccessFeedback"),
				Create("Magma", "Air", "Stone", "MixSuccessFeedback"),
				Create("Lightning", "Water", "Acid", "MixSuccessFeedback"),
				Create("Lightning", "Earth", "Glass", "MixSuccessFeedback"),
				Create("Plant", "Fire", "Coal", "MixSuccessFeedback"),
				Create("Plant", "Air", "Seed", "MixSuccessFeedback"),
				Create("Dust", "Fire", "Combustion", "MixSuccessFeedback"),
				Create("Dust", "Water", "Mud", "MixSuccessFeedback"),
				Create("Steam", "Magma", "Magma", "MixSuccessFeedback"),
				Create("Steam", "Lightning", "Ghost", "MixSuccessFeedback"),
				Create("Stone", "Lightning", "Crystal", "MixSuccessFeedback")
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
