using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace UnforeseenConsequences.Chemistry
{
	[Serializable]
	public abstract class Effect : ScriptableObject
	{
		[SerializeField] private AudioClip audioClip;

		public virtual void Trigger()
		{
			if (audioClip != null)
				AudioSource.PlayClipAtPoint(audioClip, Vector3.zero);
		}
	}
}
