namespace GildedRose
{
	public class Program
	{
		public static void Main(string[] args)
		{
			System.Console.WriteLine("OMGHAI!");
			var app = new GildedRose(new GildedRoseWebService());

			for (var i = 0; i < 31; i++)
			{
				System.Console.WriteLine("-------- day " + i + " --------");
				app.PrintReport();
			    app.UpdateQuality();
			}
		}
	}
}
