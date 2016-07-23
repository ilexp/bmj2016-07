using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace UnforeseenConsequences.Chemistry
{
	public class ReactionManager : MonoBehaviour
	{
		[SerializeField] private Substance[] substances;
		[SerializeField] private Effect[] effects;
		[SerializeField] private Effect explodeEffect;
		private Reaction[] all;

		public IEnumerable<Reaction> Reactions
		{
			get { return all; }
		}
		public Effect ExplodeEffect
		{
			get { return explodeEffect; }
		}
		public bool Initialized
		{
			get { return all != null; }
		}

		public void Init()
		{
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
		private Reaction Create(string first, string second, string result, string mixEffect)
		{
			return new Reaction(
				substances.FirstOrDefault(s => s.name == first),
				substances.FirstOrDefault(s => s.name == second),
				substances.FirstOrDefault(s => s.name == result),
				effects.FirstOrDefault(s => s.name == mixEffect));
		}
	}
}
