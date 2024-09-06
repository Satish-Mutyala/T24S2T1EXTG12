using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Calculator.Controls
{
	public sealed partial class NumberButtonControl : UserControl
	{
		// dependencies
		public string Value
		{
			get => (string)GetValue(ValueProperty);
			set => SetValue(ValueProperty, value);
		}

		public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(NumberButtonControl), null);

		// default functions
		public NumberButtonControl()
		{
			InitializeComponent();
		}

		// handle functions
		private void handleClick(object sender, RoutedEventArgs e) {
			Utils.Utils.handleClick((string)(sender as Button).Content);
		}
	}
}