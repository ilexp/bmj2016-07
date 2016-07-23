using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnforeseenConsequences.Chemistry;

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
		if (m_potContent.Count > 0)
		{
			GameObject newPotion = Instantiate(m_potionPrefab);
			newPotion.transform.parent = m_potionsBar;
			newPotion.transform.position = new Vector3(0, 0, 0);
			DraggableItem item = newPotion.GetComponent<DraggableItem>();
			if (item)
			{
				item.m_potionSubstance = m_potContent;
				m_potContent.Clear();
			}
		}
		else
		{
			Debug.Log("The pot is empty!");
		}
	}

	public void addPotion(DraggableItem i_potion)
	{
		BottlePotionOnClick potScript = GetComponent<BottlePotionOnClick>();
		if (potScript)
		{
			Debug.Log("added " + i_potion.name + " to pot");
			m_potContent.AddRange(i_potion.m_potionSubstance);
			m_potContent = Solver.Solve(m_potContent);
		}
	}
}
