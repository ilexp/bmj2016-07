public class HealthBar
{
	private int initialHp {get;}  // initial hp value, might be interesting later
	private int currentHp {get;}  // hp at the moment
	private int maxHp {get; set;}  // hp the character can have at maximum
	private int minHp {get; set;}  // hp the character must have at least, probably 0

	public HealthBar(int minHp, int maxHp, int initialHp)
	{
		minHp = minHp;
		maxHp = maxHp;
		initialHp = initialHp;
		currentHp = initialHp;
	}

	public void decreaseHp(int decreaseAmount)
	{
		currentHp = Math.Max(currentHp - decreaseHp, minHp);
		updateOnHpChange();
	}

	public void increaseHp(int increaseAmount)
	{
		currentHp = Math.Max(currentHp + increaseHp, maxHp);
		updateOnHpChange();
	}

	public void increaseMaxHp(int increaseAmount)
	{
		maxHp = Math.Max(maxHp + increaseAmount, minHp);
	}

	public void decreaseMaxHp(int decreaseAmount)
	{
		maxHp = Math.Max(maxHp - decreaseAmount, minHp);
	}

	public void increaseMinHp(int increaseAmount)
	{
		minHp = Math.Min(minHp + increaseAmount, maxHp);
	}

	public void decreaseMinHp(int decreaseAmount)
	{
		minHp = Math.Min(minHp - decreaseAmount, maxHp);
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
