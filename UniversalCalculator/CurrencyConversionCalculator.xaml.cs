using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Calculator
{
	public sealed partial class CurrencyConversionCalculator : Page
	{
		// Define the conversion rates
		private Dictionary<string, Dictionary<string, double>> conversionRates = new Dictionary<string, Dictionary<string, double>>()
		{
			{"US Dollar", new Dictionary<string, double>(){
				{"Euro", 0.85189982},
				{"British Pound", 0.72872436},
				{"Indian Rupee", 74.257327}
			}},
			{"Euro", new Dictionary<string, double>(){
				{"US Dollar", 1.1739732},
				{"British Pound", 0.8556672},
				{"Indian Rupee", 87.00755}
			}},
			{"British Pound", new Dictionary<string, double>(){
				{"US Dollar", 1.371907},
				{"Euro", 1.1686692},
				{"Indian Rupee", 101.68635}
			}},
			{"Indian Rupee", new Dictionary<string, double>(){
				{"US Dollar", 0.011492628},
				{"Euro", 0.013492774},
				{"British Pound", 0.0098339397}
			}},
		};

		public CurrencyConversionCalculator()
		{
			this.InitializeComponent();
		}

		private void calcButton_Click(object sender, RoutedEventArgs e)
		{
			// Get selected currencies and amount
			string fromCurrency = fromValueComboBox.SelectedItem?.ToString();
			string toCurrency = toValueComboBox.SelectedItem?.ToString();
			double amount;

			if (double.TryParse(amountValueTextBox.Text, out amount))
			{
				// Handle conversion for the same currency
				if (fromCurrency == toCurrency)
				{
					// No conversion needed
					entryAmount.Text = $"{amount} {fromCurrency} =";
					currencyConversion.Text = $"{amount} {toCurrency}";
					conversionDetailsCountryB.Text = "No conversion required.";
					conversionDetailsCountryC.Text = "";
				}
				else
				{
					// Perform the conversion
					double convertedAmount = ConvertCurrency(fromCurrency, toCurrency, amount);

					// Display the main conversion result
					entryAmount.Text = $"{amount} {fromCurrency} =";
					currencyConversion.Text = $"{convertedAmount} {toCurrency}";

					// Display conversion details for other currencies
					DisplayConversionDetails(fromCurrency, toCurrency, amount);
				}
			}
			else
			{
				// Handle invalid input
				entryAmount.Text = "Invalid amount entered.";
				currencyConversion.Text = "";
				conversionDetailsCountryB.Text = "";
				conversionDetailsCountryC.Text = "";
			}
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			// Navigate back to the main page
			//Return to main menu			
			HomePage homePage = new HomePage();
			this.Content = homePage;
		}

		private double ConvertCurrency(string fromCurrency, string toCurrency, double amount)
		{
			if (conversionRates.ContainsKey(fromCurrency) && conversionRates[fromCurrency].ContainsKey(toCurrency))
			{
				double rate = conversionRates[fromCurrency][toCurrency];
				return amount * rate;
			}
			else
			{
				// Handle unsupported currency conversion
				return 0.0;
			}
		}

		private void DisplayConversionDetails(string fromCurrency, string toCurrency, double amount)
		{
			// Display conversion details to other two currencies
			List<string> currencies = new List<string> { "US Dollar", "Euro", "British Pound", "Indian Rupee" };
			currencies.Remove(fromCurrency); // Remove the original currency
			currencies.Remove(toCurrency); // Also remove the 'To' currency

			// Remaining currencies
			string currencyB = currencies[0];
			string currencyC = currencies[1];

			// Convert to remaining currencies
			double convertedAmountB = ConvertCurrency(fromCurrency, currencyB, amount);
			double convertedAmountC = ConvertCurrency(fromCurrency, currencyC, amount);

			// Display results
			conversionDetailsCountryB.Text = $"{amount} {fromCurrency} = {convertedAmountB} {currencyB}";
			conversionDetailsCountryC.Text = $"{amount} {fromCurrency} = {convertedAmountC} {currencyC}";
		}
	}
}