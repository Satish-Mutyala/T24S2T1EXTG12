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
			private void mathCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}
		private void mortgageCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}
		private void currencyCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}
		private void miscellaneousConverterButton_Click(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}
		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}

	}
}