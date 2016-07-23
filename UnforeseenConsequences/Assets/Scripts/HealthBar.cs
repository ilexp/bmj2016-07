public class HealthBar
{
	private int initialHp;  // initial hp value, might be interesting later
	private int currentHp;  // hp at the moment
	private int maxHp;  // hp the character can have at maximum
	private int minHp;  // hp the character must have at least, probably 0

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
