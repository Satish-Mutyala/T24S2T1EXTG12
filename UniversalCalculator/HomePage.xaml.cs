using System;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class HomePage : Page
	{
		public HomePage()
		{
			this.InitializeComponent();
		}
		private void pageLoaded(object sender, RoutedEventArgs e)
		{

		}
		//Button to redirect to MathCalcualtor page (MainPage)
		private void mathCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			MainPage mainPage = new MainPage();
			this.Content = mainPage;
		}
		private void mortgageCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			MortgageCalculator mortgageCalculator = new MortgageCalculator();
			this.Content = mortgageCalculator;
		}
		private void currencyCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			CurrencyConversionCalculator currencyConversionCalculator = new CurrencyConversionCalculator();
			this.Content = currencyConversionCalculator;
		}
		private void miscellaneousConverterButton_Click(object sender, RoutedEventArgs e)
		{
			MiscellaneousConverter miscellaneousConverter = new MiscellaneousConverter();
			this.Content = miscellaneousConverter;
		}
		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0); // Exits with status code 0
		}

	}
}
