using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238




namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

	
		private void CalculateButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				// Get user inputs and parse them to respective types
				double principal = double.Parse(PrincipalBorrow.Text);
				int years = int.Parse(Years.Text);
				int months = int.Parse(Months.Text);
				double yearlyInterestRate = double.Parse(YearlyInterestRate.Text)/100;

				// Convert yearly interest rate to monthly interest rate (decimal form)
				double monthlyInterestRate = yearlyInterestRate / 12;
				MonthlyInterestRate.Text = monthlyInterestRate.ToString("F4") + "%";

				// Total number of months for the loan (years converted to months + additional months)
				int totalMonths = (years * 12) + months;

				// Calculate the mortgage repayment using the formula
				// M = P [ i(1 + i)^n ] / [ (1 + i)^n – 1 ]
				double powValue = Math.Pow(1 + monthlyInterestRate, totalMonths);
				double monthlyRepayment = principal * (monthlyInterestRate * powValue) / (powValue - 1);

				// Display the result in the MonthlyRepayment text box, formatted as currency
				MonthlyRepayment.Text = monthlyRepayment.ToString("C2");
			}
			catch (Exception ex)
			{
				ContentDialog dialog = new ContentDialog
				{
					Title = "Erro",
					Content = ex.Message,
					CloseButtonText = "Ok"
				};
			}
			
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			//Return to main menu			
			HomePage homePage = new HomePage();
			this.Content = homePage;
		}
	}
}
