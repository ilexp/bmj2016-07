using UnityEngine;

public class HealthBar
{
	private int initialHp;  // initial hp value, might be interesting later
	private int currentHp;  // hp at the moment
	private int maxHp;  // hp the character can have at maximum
	private int minHp;  // hp the character must have at least, probably 0

	public HealthBar(int minHp, int maxHp, int initialHp)
	{
		this.minHp = minHp;
		this.maxHp = maxHp;
		this.initialHp = initialHp;
		this.currentHp = initialHp;
	}

	public void decreaseHp(int decreaseAmount)
	{
		currentHp = Mathf.Max(currentHp - decreaseAmount, minHp);
		updateOnHpChange();
	}

	public void increaseHp(int increaseAmount)
	{
		currentHp = Mathf.Max(currentHp + increaseAmount, maxHp);
		updateOnHpChange();
	}

	public void fillHp()
	{
		currentHp = maxHp;
		updateOnHpChange();
	}

	public void depleteHp()
	{
		currentHp = minHp;
		updateOnHpChange();
	}

	public void updateOnHpChange()
	{
		// redraw stuff
	}
}
