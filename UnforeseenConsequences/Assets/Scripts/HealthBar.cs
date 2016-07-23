using UnityEngine;

public class HealthBar
{
	private int initialHp {get;}  // initial hp value, might be interesting later
	private int currentHp {get;}  // hp at the moment
	private int maxHp {get; set;}  // hp the character can have at maximum
	private int minHp {get; set;}  // hp the character must have at least, probably 0

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

	public void increaseMaxHp(int increaseAmount)
	{
		maxHp = Math.Max(maxHp + increaseAmount, minHp);
		updateOnMaxHpChange();
	}

	public void decreaseMaxHp(int decreaseAmount)
	{
		maxHp = Math.Max(maxHp - decreaseAmount, minHp);
		updateOnMaxHpChange();
	}

	public void increaseMinHp(int increaseAmount)
	{
		minHp = Math.Min(minHp + increaseAmount, maxHp);
		updateOnMinHpChange();
	}

	public void decreaseMinHp(int decreaseAmount)
	{
		minHp = Math.Min(minHp - decreaseAmount, maxHp);
		updateOnMinHpChange();
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

	public void updateOnMinHpChange()
	{
		// redraw stuff
	}

	public void updateOnMaxHpChange()
	{
		// redraw stuff
	}
}
