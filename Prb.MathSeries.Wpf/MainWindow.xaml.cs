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

namespace Prb.MathSeries.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i < 21; i++)
            {
                cmbBaseNumber.Items.Add(i);
                cmbExponent.Items.Add(i);
            }
            for (int i = 3; i < 51; i++)
            {
                cmbFibonacci.Items.Add(i);
            }
            for (int i = 1; i < 51; i++)
            {
                cmbPrimeNumber.Items.Add(i);
            }
        }

        private void CmbBaseNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstPower.Items.Clear();

            if (cmbBaseNumber.SelectedIndex == null) return;
            if (cmbExponent.SelectedIndex == null) return;
            int baseNumber = int.Parse(cmbBaseNumber.SelectedItem.ToString());
            int maxExponent = int.Parse(cmbExponent.SelectedItem.ToString());
            for (int exponent = 1; exponent <= maxExponent; exponent++)
            {
                double result = Math.Pow(baseNumber, exponent);
                lstPower.Items.Add($"{baseNumber}^{exponent} = {result}");
            }
        }

        private void CmbExponent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbFibonacci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int amount = (int)cmbFibonacci.SelectedItem;

            lstFibonacci.Items.Clear();
            lstFibonacci.Items.Add(0);
            lstFibonacci.Items.Add(1);

            int secondLast = 0;
            int last = 1;

            for (int number = 3; number <= amount; number++)
            {
                int nextFibonacci = secondLast + last;
                lstFibonacci.Items.Add(nextFibonacci);

                secondLast = last;
                last = nextFibonacci;
            }
        }
            private void CmbPrimeNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
            if (cmbPrimeNumber.SelectedItem == null) return;
                
            lstPrimeNumber.Items.Clear();
            int amount = (int)cmbPrimeNumber.SelectedItem;
            int numberOfPrimes = 0;
            int number = 2;

            while(numberOfPrimes < amount) 
            {
                if (IsPrime(number))
                {
                    numberOfPrimes++;
                    lstPrimeNumber.Items.Add(number);
                }
                number++;
            }
            }
        private bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            int divideStart = number / 2;

            for(int divide = divideStart; divide > 1; divide--)
            {
                if (number % divide == 0)
                {
                    return false;
                }
            }
            return true;
        }
        }
    } 

