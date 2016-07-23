using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace UnforeseenConsequences.Chemistry
{
	[Serializable]
	[CreateAssetMenu]
	public class Substance : ScriptableObject
	{
		[SerializeField] private string displayedName;
		[SerializeField] private Color32 color;

		public string DisplayedName
		{
			get { return this.displayedName; }
		}
		public Color32 Color
		{
			get { return this.color; }
		}
	}
}
