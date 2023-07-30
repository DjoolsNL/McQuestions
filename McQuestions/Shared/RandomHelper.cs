namespace McQuestions.Shared
{
	public static class RandomHelper
	{
		private static readonly Random random = new Random();

		public static int Next(int minValue, int maxValue)
		{
			lock (random)
			{
				return random.Next(minValue, maxValue);
			}
		}
	}

}
