namespace Pluralize
{
	public static class PluralizeTask
	{
		public static string PluralizeRubles(int count)
		{

            string plural = "рублей";
            count %= 100;
            if (count > 10 && count < 15)
            {
                plural = "рублей";
            }
            else if (count % 10 == 1)
            {
                plural = "рубль";
            }
            else if (count % 10 > 1 && count % 10 < 5)
            {
                plural = "рубля";
            }
            return plural;
        }
	}
}