using System;
using System.Collections.Generic;

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
	}
}
