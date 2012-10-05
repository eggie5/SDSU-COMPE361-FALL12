using System;
using NUnit.Framework;
using lab4SimonSays;
using System.Drawing;

namespace SimonSaysTests
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void TestCase ()
		{

			SimonSays game = new SimonSays ();

			Color [] expected_colors = new Color[] {
				Color.Red,
				Color.Green,
				Color.Blue,
				Color.Yellow
			};

			Assert.AreEqual (expected_colors, game.Colors);

			int length = 10;
			Color [] seq = game.newSequence (length);
			Assert.AreEqual (length, seq.Length);

			//user types hits 1 correct color
			Color [] user_colors = new Color[]{Color.Red};
			game.newSequence (new Color[]{Color.Red, Color.Blue});


			int actual_result = game.Compare (user_colors);
			int expected = 0;
			Assert.AreEqual (expected, actual_result);

			Assert.AreEqual (-1, game.Compare(new Color[]{Color.Blue}));

			//now test that a sequence is correct
			game.newSequence(new Color[]{Color.Red, Color.Red, Color.Yellow});

			Assert.AreEqual(1, game.Compare(new Color[]{Color.Red, Color.Red, Color.Yellow}));

		}
	}
}

