using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Calculator
{
    public partial class ModProgrammer : Window
    {
        public ModProgrammer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string buttonText = button.Content.ToString();

                var calculator = this.DataContext as ProgrammerCalc;

                switch (buttonText)
                {
                    case var digit when int.TryParse(buttonText, out int num):
                        calculator?.AddDigit(num);
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
                    case "<<":
                        calculator?.LeftBitShift();
                        break;
                    case ">>":
                        calculator?.RightBitShift();
                        break;
                    case "%":
                        calculator?.Modulo();
                        break;
                    case "+/-":
                        calculator?.ReverseSign();
                        break;
                    case "x^2":
                        calculator?.Squared();
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
                        if (selectedIndex != -1)
                            calculator?.MemoryAdd(selectedIndex);
                        break;
                    }
                    case "M-":
                    {
                        var selectedIndex = Memory.SelectedIndex;
                        if (selectedIndex != -1)
                            calculator?.MemorySubtract(selectedIndex);
                        break;
                    }
                    default:
                        break;
                }
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            var calculator = this.DataContext as ProgrammerCalc;

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
                switch (e.Key)
                {
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
                var calculator = this.DataContext as ProgrammerCalc;
                calculator?.CopyToClipboard();
            }
        }

        private void PasteButton_Click(object sender, RoutedEventArgs e)
        {
            MenuItem helpButton = sender as MenuItem;
            if (helpButton != null)
            {
                var calculator = this.DataContext as ProgrammerCalc;
                calculator?.PasteToClipboard();
            }
        }

        private void CutButton_Click(object sender, RoutedEventArgs e)
        {
            MenuItem helpButton = sender as MenuItem;
            if (helpButton != null)
            {
                var calculator = this.DataContext as ProgrammerCalc;
                calculator?.CutToClipboard();
            }
        }
        
        private void StandardMode_Click(object sender, RoutedEventArgs e)
        {
            ModStandard standardWindow = new ModStandard();

            var xCoords = this.Left;
            var yCoords = this.Top;

            this.Close();

            standardWindow.Left = xCoords;
            standardWindow.Top = yCoords;
            standardWindow.Show();
        }

        private void ChangeBase_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string buttonText = button.Content.ToString();

                var calculator = this.DataContext as ProgrammerCalc;

                switch (buttonText)
                {
                    case "Dec":
                        calculator?.ToggleDec();
                        break;
                    case "Hex":
                        calculator?.ToggleHex();
                        break;
                    case "Oct":
                        calculator?.ToggleOct();
                        break;
                    case "Bin":
                        calculator?.ToggleBin();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
