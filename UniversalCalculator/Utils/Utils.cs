using System;
using System.Data;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Calculator.Utils
{
	public static class Utils
	{
		// Executed an arithematic expresssion   e.g. 2 + 3 * 4
		private static double executeExpression(string text)							// KT changed int to double
		{
			string number = new DataTable().Compute(text, "").ToString();
			double numberDouble = Convert.ToDouble(number);

			return numberDouble;                                       // KT changed return Convert.ToInt16(numberDouble);   to  return numberDouble;
		}

		private static bool isNumeric(char character)
		{
			return int.TryParse(character.ToString(), out _);
		}

		public static void handleClick(string number)
		{
			TextBlock primaryDisplay = MainPage.mainPage.primaryDisplay;
			TextBlock secondaryDisplay = MainPage.mainPage.secondaryDisplay;
			TextBlock errorDisplay = MainPage.mainPage.errorDisplay;

			// the number cannot have more than 6 digits
			if (primaryDisplay.Text.Length < 6)
			{
				if (!(primaryDisplay.Text.Length == 0 && number == "0"))
				{
					if (secondaryDisplay.Text.Length + primaryDisplay.Text.Length <= 50)
					{
						primaryDisplay.Text += number;
					}
					else
					{
						errorDisplay.Text = "The exp. can have until 50 digits";
						FlyoutBase.ShowAttachedFlyout(primaryDisplay);
					}
				}
			}
			else
			{
				errorDisplay.Text = "The number can have until 6 digits";
				FlyoutBase.ShowAttachedFlyout(primaryDisplay);
			}
		}

		// triggered when an operation such as +, -, * or / is pressed
		public static void handleOperationClick(string operation)
		{
			TextBlock primaryDisplay = MainPage.mainPage.primaryDisplay;
			TextBlock secondaryDisplay = MainPage.mainPage.secondaryDisplay;

			if (primaryDisplay.Text.Length + secondaryDisplay.Text.Length < 50)
			{
				if (secondaryDisplay.Text.Length != 0)
				{
					if (!isNumeric(secondaryDisplay.Text[secondaryDisplay.Text.Length - 1]) && primaryDisplay.Text.Length == 0)
						secondaryDisplay.Text = secondaryDisplay.Text.Substring(0, secondaryDisplay.Text.Length - 1) + operation;
					else
						secondaryDisplay.Text += primaryDisplay.Text + operation;
				}
				else if (primaryDisplay.Text.Length != 0)
				{
					secondaryDisplay.Text += primaryDisplay.Text + operation;
				}

				primaryDisplay.Text = "";
			}
		}

		// Triggered when the clear button is pressed
		public static void handleClearButtonClick()
		{
			MainPage.mainPage.primaryDisplay.Text = "";
			MainPage.mainPage.secondaryDisplay.Text = "";
		}

		// Triggered when the equal button is pressed
		public static void handleEqualButtonClick()
		{
			TextBlock primaryDisplay = MainPage.mainPage.primaryDisplay;
			TextBlock secondaryDisplay = MainPage.mainPage.secondaryDisplay;
			TextBlock errorDisplay = MainPage.mainPage.errorDisplay;

			try
			{
				primaryDisplay.Text = executeExpression(secondaryDisplay.Text + primaryDisplay.Text).ToString();   // KT inter-changed the primaryDisplay.Text around with the SecondaryDisplay.Text

				if (primaryDisplay.Text.Length > 6)
					primaryDisplay.FontSize = 48;
				secondaryDisplay.Text = "";
			}
			catch
			{
				errorDisplay.Text = "There's an error in the exp.";
				FlyoutBase.ShowAttachedFlyout(primaryDisplay);
			}
		}

		public static void handleBackspace()
		{
			TextBlock primaryDisplay = MainPage.mainPage.primaryDisplay;

			if (primaryDisplay.Text.Length > 0)
				primaryDisplay.Text = primaryDisplay.Text.Substring(0, primaryDisplay.Text.Length - 1);
		}
	}
}