using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator
{
    public partial class ModStandard : Window
    {
    
        public ModStandard()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string buttonText = button.Content.ToString();

                var calculator = this.DataContext as Calcs;

                switch (buttonText)
                {
                    case var digit when int.TryParse(buttonText, out int num):
                        calculator?.AddDigit(num);
                        break;
                    case ".":
                        calculator?.MakeDecimal();
                        break;
                    case "C":
                        calculator?.ClearResult();
                        break;
                    case "CE":
                        calculator?.ClearRightOperand();
                        break;
                    case "DEL":
                        calculator?.DeleteDigit();
                        break;
                    case "=":
                        calculator?.Equals();
                        break;
                    case "+":
                        calculator?.Addition();
                        break;
                    case "-":
                        calculator?.Subtraction();
                        break;
                    case "*":
                        calculator?.Multiplication();
                        break;
                    case "÷":
                        calculator?.Division();
                        break;
                    case "x^2":
                        calculator?.Squared();
                        break;
                    case "1/x":
                        calculator?.Inverted();
                        break;
                    case "%":
                        calculator?.Percent();
                        break;
                    case "√x":
                        calculator?.SquareRoot();
                        break;
                    case "+/-":
                        calculator?.ReverseSign();
                        break;
                    case "MC":
                        calculator?.MemoryClear();
                        break;
                    case "MR":
                        calculator?.MemoryRecall();
                        break;
                    case "MS":
                        calculator?.MemoryStore();
                        break;
                    case "M+":
                    {
                        var selectedIndex = Memory.SelectedIndex;
                        if(selectedIndex != -1)
                            calculator?.MemoryAdd(selectedIndex);
                        break;
                    }
                    case "M-":
                    {
                        var selectedIndex = Memory.SelectedIndex;
                        if(selectedIndex != -1)
                            calculator?.MemorySubtract(selectedIndex);
                        break;
                    }
            }
            }
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            var calculator = this.DataContext as Calcs;

            // Numeric keys
            if (e.Key >= Key.D0 && e.Key <= Key.D9 && Keyboard.IsKeyDown(Key.LeftShift) != true)
            {
                int digit = e.Key - Key.D0;
                calculator?.AddDigit(digit);
            }
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                int digit = e.Key - Key.NumPad0;
                calculator?.AddDigit(digit);
            }
            else
            {
                /// Mai am aici de agasit codurile pentru tastele de operatii
                switch (e.Key)
                {
                    case Key.OemPeriod:
                    case Key.Decimal:
                        calculator?.MakeDecimal();
                        break;
                    case Key.Back:
                        calculator?.DeleteDigit();
                        break;
                    case Key.Enter:
                        calculator?.Equals();
                        break;
                    case Key.Escape:
                        calculator?.ClearResult();
                        break;
                    case Key.Add:
                    case Key.OemPlus when Keyboard.IsKeyDown(Key.LeftShift):
                        calculator?.Addition();
                        break;
                    case Key.Subtract:
                    case Key.OemMinus:
                        calculator?.Subtraction();
                        break;
                    case Key.Multiply:
                    case Key.D8 when Keyboard.IsKeyDown(Key.LeftShift):
                        calculator?.Multiplication();
                        break;
                    case Key.Divide:
                    case Key.Oem2:
                        calculator?.Division();
                        break;
                    case Key.D5 when Keyboard.IsKeyDown(Key.LeftShift):
                        calculator?.Percent();
                        break;
                    case Key.F9:
                        calculator?.ReverseSign();
                        break;
                }
            }
        }

            private void MenuButton_Click(object sender, RoutedEventArgs e)
            {
                Button menuButton = sender as Button;
                if (menuButton != null)
                {
                    ContextMenu menu = FindResource("Menu") as ContextMenu;
                    if (menu != null)
                    {
                        menu.PlacementTarget = menuButton;
                        menu.IsOpen = true;
                    }
                }
            }

            private void ChooseMode_Click(object sender, RoutedEventArgs e)
            {
                Button menuButton = sender as Button;
                if (menuButton != null)
                {
                    ContextMenu menu = FindResource("ModeMenu") as ContextMenu;
                    if (menu != null)
                    {
                        menu.PlacementTarget = menuButton;
                        menu.IsOpen = true;
                    }
                }
            }

            private void DigitGrouping_Click(object sender, RoutedEventArgs e)
            {
                MenuItem groupingButton = sender as MenuItem;
                if (groupingButton != null)
                {
                    var calculator = this.DataContext as Calcs;
                    calculator?.ToggleGrouping();
                }
            }

            private void AboutButton_Click(object sender, RoutedEventArgs e)
            {
                MenuItem helpButton = sender as MenuItem;
                if (helpButton != null)
                {
                    MessageBox.Show(this, "Implementat de: Popa Marian-Iulian\nGrupa: 10LF332", "About");
                }
            }
        
            private void CopyButton_Click(object sender, RoutedEventArgs e)
            {
                MenuItem helpButton = sender as MenuItem;
                if (helpButton != null)
                {
                    var calculator = this.DataContext as Calcs;
                    calculator?.CopyToClipboard();
                }
            }

            private void PasteButton_Click(object sender, RoutedEventArgs e)
            {
                MenuItem helpButton = sender as MenuItem;
                if (helpButton != null)
                {
                    var calculator = this.DataContext as Calcs;
                    calculator?.PasteToClipboard();
                }
            }

            private void CutButton_Click(object sender, RoutedEventArgs e)
            {
                MenuItem helpButton = sender as MenuItem;
                if (helpButton != null)
                {
                    var calculator = this.DataContext as Calcs;
                    calculator?.CutToClipboard();
                }
            }

            private void ProgrammerMode_Click(object sender, RoutedEventArgs e)
            {
                ModProgrammer programmerWindow = new ModProgrammer();

                var xCoords = this.Left;
                var yCoords = this.Top;

                this.Close();

                programmerWindow.Left = xCoords;
                programmerWindow.Top = yCoords;
                programmerWindow.Show();
            }
    }
}

