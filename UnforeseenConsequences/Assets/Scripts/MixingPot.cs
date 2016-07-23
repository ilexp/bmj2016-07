using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

using UnforeseenConsequences.Chemistry;

namespace UnforeseenConsequences
{
	public class MixingPot : MonoBehaviour
	{
		[SerializeField] private Image middleImage;
		[SerializeField] private Substance content;

		public Substance Content
		{
			get { return this.content; }
			set { this.content = value; this.UpdateAppearance(); }
		}

		private void OnValidate()
		{
			this.UpdateAppearance();
		}

		private void UpdateAppearance()
		{
			if (this.middleImage == null) return;
			if (this.content == null)
			{
				this.middleImage.color = new Color(0, 0, 0, 0);
			}
			else
			{ 
				this.middleImage.color = this.content.Color;
			}
		}

		public void addPotion(DraggableItem i_potion)
		{
			Potion potionScript = i_potion.GetComponent<Potion>();
			BottlePotionOnClick potScript = GetComponent<BottlePotionOnClick>();
			if (potionScript && potScript)
			{
				Debug.Log("added " + i_potion.name + " to pot");
				List<Substance> substances = new List<Substance>();
				if (Content != null)
				{
					substances.Add(Content);
				}
				substances.Add(potionScript.Content);
				Content = Solver.Solve(substances).FirstOrDefault<Substance>();
			}
		}
	}
}
