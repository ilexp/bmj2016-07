using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnforeseenConsequences.Chemistry;

namespace UnforeseenConsequences
{
	public class BottlePotionOnClick : InteractiveObject
	{
		public GameObject m_potionPrefab;
		public Transform m_potionsBar;

		private List<Substance> m_potContent;

		void Start()
		{
			m_potContent = new List<Substance>();
		}

		public override void handleMouseDown()
		{
			// create new potion if non-empty
			MixingPot potScript = GetComponent<MixingPot>();
			if (potScript && potScript.Content)
			{
				// create new potion
				GameObject newPotion = Instantiate(m_potionPrefab);
				newPotion.transform.position = m_potionsBar.transform.position;
				newPotion.transform.parent = m_potionsBar;
				DraggableItem item = newPotion.GetComponent<DraggableItem>();
				if (item)
				{
					// pour pot content into potion
					Potion potionScript = item.GetComponent<Potion>();
					potionScript.Content = potScript.Content;
					potScript.Content = null;
				}
			}
			else
			{
				Debug.Log("The pot is empty!");
			}
		}
	}
}