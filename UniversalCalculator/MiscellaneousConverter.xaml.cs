using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Calculator
{
	/// <summary>
	/// Page to hold the logic for Miscellaneous Converter
	/// </summary>
	public sealed partial class MiscellaneousConverter : Page
	{
		const double TEMP_CELCIUS_TO_FAHRENHEIT_CONVESION_RATE = 1.8;
		//const double DISTANCE_METRES_TO_FOOT_CONVESION_RATE = 3.28084;
		const double DISTANCE_FOOT_TO_METRES_CONVESION_RATE = 0.3048;
		const double MASS_KILOGRAMS_TO_POUNDS_CONVESION_RATE = 0.45359237;
		const double PRESSURE_KPI_TO_PSI_CONVESION_RATE = 6.89475729;


		public MiscellaneousConverter()
		{
			this.InitializeComponent();
		}
		private void pageLoaded(object sender, RoutedEventArgs e)
		{

		}

		// Handler to convert Temperature from Celsius to Fahrenheit
		private void convertButton_Click(object sender, RoutedEventArgs e)
		{
			double tempInCelcius;
			double tempInFahrenheit;

			double distanceInMetres;
			double distanceInFoot;

			double massInKilograms;
			double massInPounds;

			double pressureInKPA;
			double pressureInPsi;


			// Convert Temperature in Celcius to Fahrenheit if user entered any value for temperatureTextBox filed
			if (temperatureInCelsiusTextBox.Text != "")
			{
				tempInCelcius = double.Parse(temperatureInCelsiusTextBox.Text);
				temperatureInFahrenheitOutputTextBox.Text = ((tempInCelcius * TEMP_CELCIUS_TO_FAHRENHEIT_CONVESION_RATE) + 32).ToString() + " Fahrenheit";
			}
			if (temperatureInFahrenheitTextBox.Text != "")
			{
				tempInFahrenheit = double.Parse(temperatureInFahrenheitTextBox.Text);
				temperatureInCelsiusOutputTextBox.Text = ((tempInFahrenheit - 32) * 5 / 9).ToString() + " Celsius";
			}

			// Convert distance in Meters to Foot if user entered any value for distanceInMetresTextBox filed
			if (distanceInMetresTextBox.Text != "")
			{
				distanceInMetres = double.Parse(distanceInMetresTextBox.Text);
				distanceInFootOutputTextBox.Text = (distanceInMetres / DISTANCE_FOOT_TO_METRES_CONVESION_RATE).ToString() + " Foot";
			}
			if (distanceInFootTextBox.Text != "")
			{
				distanceInFoot = double.Parse(distanceInFootTextBox.Text);
				distanceInMetresOutputTextBox.Text = (distanceInFoot * DISTANCE_FOOT_TO_METRES_CONVESION_RATE).ToString() + " Metres";
			}

			// Convert mass in Kilograms to Pounds if user entered any value for massInKilogramsTextBox filed
			if (massInKilogramsTextBox.Text != "")
			{
				massInKilograms = double.Parse(massInKilogramsTextBox.Text);
				massInPoundsOutputTextBox.Text = (massInKilograms / MASS_KILOGRAMS_TO_POUNDS_CONVESION_RATE).ToString() + " Pounds";
			}
			if (massInPoundsTextBox.Text != "")
			{
				massInPounds = double.Parse(massInPoundsTextBox.Text);
				massInKilogramsOutputTextBox.Text = (massInPounds * MASS_KILOGRAMS_TO_POUNDS_CONVESION_RATE).ToString() + " Kgs";
			}
			// Convert Pressure Kpa to PSI if user entered any value for massInKilogramsTextBox filed
			if (pressureInKpaTextBox.Text != "")
			{
				pressureInKPA = double.Parse(pressureInKpaTextBox.Text);
				pressureInPsiOutputTextBox.Text = (pressureInKPA / PRESSURE_KPI_TO_PSI_CONVESION_RATE).ToString() + " PSIs";
			}
			if (pressureInPsiTextBox.Text != "")
			{
				pressureInPsi = double.Parse(pressureInPsiTextBox.Text);
				pressureInKpaOutputTextBox.Text = (pressureInPsi * PRESSURE_KPI_TO_PSI_CONVESION_RATE).ToString() + " KPAs";
			}

		}

		// Handler to navigate to navigate to homepage
		private void homeButton_Click(object sender, RoutedEventArgs e)
		{
			HomePage homePage = new HomePage();
			this.Content = homePage;
		}
		// Handler to handle the clear logic, clear  fields when user clicked clear button
		private void handleClearButton_Click(object sender, RoutedEventArgs e)
		{
			temperatureInCelsiusTextBox.Text = "";
			temperatureInFahrenheitOutputTextBox.Text = "";
			temperatureInFahrenheitTextBox.Text = "";
			temperatureInCelsiusOutputTextBox.Text = "";
			distanceInMetresTextBox.Text = "";
			distanceInMetresOutputTextBox.Text = "";
			distanceInFootTextBox.Text = "";
			distanceInFootOutputTextBox.Text = "";
			massInKilogramsTextBox.Text = "";
			massInKilogramsOutputTextBox.Text = "";
			massInPoundsTextBox.Text = "";
			massInPoundsOutputTextBox.Text = "";
			pressureInKpaTextBox.Text = "";
			pressureInKpaOutputTextBox.Text = "";
			pressureInPsiTextBox.Text = "";
			pressureInPsiOutputTextBox.Text = "";
		}

	}
}


