using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace UnforeseenConsequences.Chemistry
{
	[Serializable]
	[CreateAssetMenu]
	public class CreateSubstanceEffect : Effect
	{
		[SerializeField] private Substance createdSubstance;

		public Substance CreatedSubstance
		{
			get { return this.createdSubstance; }
		}
	}
}
