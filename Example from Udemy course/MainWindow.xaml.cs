using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Example_from_Udemy_course
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		double lastNumber, result;
		SelectedOperator selectedOperator;
		public MainWindow()
		{
			InitializeComponent();

			//resultLabel.Content = "34";

			acButton.Click += AcButton_Click;
			negativeButton.Click += NegativeButton_Click;
			PercentageButton.Click += PercentageButton_Click;
			equalButton.Click += EqualButton_Click;
			// you either should have the click defined in the xaml file and dont have the click event here
			// or have it in the xaml file and remove the event from here,. if you have it in both places it will run twice
			// C# detects and links "nameofthebutton_Click" to the actual button automatically

		}

		private void EqualButton_Click(object sender, RoutedEventArgs e) // AKA result button: spits out the result 
		{
			double newNumber;
			if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
			{
				switch (selectedOperator)
				{
					case SelectedOperator.Addition:
						result = SimpleMath.Add(lastNumber, newNumber);
						break;
					case SelectedOperator.Substraction:
						result = SimpleMath.Substract(lastNumber, newNumber);
						break;
					case SelectedOperator.Multiplication:
						result = SimpleMath.Multiply(lastNumber, newNumber);
						break;
					case SelectedOperator.Division:
						result = SimpleMath.Divide(lastNumber, newNumber);
						break;

				}
				resultLabel.Content = result.ToString();
				return;
			}

		}

		private void PercentageButton_Click(object sender, RoutedEventArgs e)
		{
			if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
			{
				lastNumber = lastNumber / 100;
				resultLabel.Content = lastNumber.ToString();
			}
		}

		private void NegativeButton_Click(object sender, RoutedEventArgs e)
		{
			if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
			{
				lastNumber = lastNumber * -1;
				resultLabel.Content = lastNumber.ToString();
			}
		}

		private void AcButton_Click(object sender, RoutedEventArgs e)
		{
			resultLabel.Content = "0";
		}

		private void OperationButton_Click(object sender, RoutedEventArgs e)
		{
			if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
			{
				resultLabel.Content = "0";
			}

			if (sender == divideButton)
			{
				selectedOperator = SelectedOperator.Division;
			}
			if (sender == multiplyButton)
			{
				selectedOperator = SelectedOperator.Multiplication;
			}
			if (sender == substractionButton)
			{
				selectedOperator = SelectedOperator.Substraction;
			}
			if (sender == addButton)
			{
				selectedOperator = SelectedOperator.Addition;
			}
		}

		private void decimalButton_Click(object sender, RoutedEventArgs e)
		{
			if (resultLabel.Content.ToString().Contains("."))
			{
				// Do nothing
			}
			else
			{
				resultLabel.Content = $"{resultLabel.Content}.";

			}
		}

		private void NumberButton_Click(object sender, RoutedEventArgs e)
		{
			int selectedValue = int.Parse((sender as Button).Content.ToString());
			if (resultLabel.Content.ToString() == "0")
			{
				resultLabel.Content = $"{selectedValue}";
			}
			else resultLabel.Content = $"{resultLabel.Content}{selectedValue}";

		}
	}
	public enum SelectedOperator
	{
		Addition,
		Substraction,
		Multiplication,
		Division
	}

	public class SimpleMath
	{
		// access modifiers
		public static double Add(double n1, double n2)
		{
			return n1 + n2;
		}
		public static double Substract(double n1, double n2)
		{
			return n1 - n2;
		}
		public static double Multiply(double n1, double n2)
		{
			return n1 * n2;
		}
		public static double Divide(double n1, double n2)
		{
			return n1 / n2;
		}
	}
}
