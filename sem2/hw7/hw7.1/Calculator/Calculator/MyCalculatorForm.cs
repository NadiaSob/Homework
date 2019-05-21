using System;
using System.Windows.Forms;

namespace homework
{
    public partial class MyCalculatorForm : Form
    {
        private double firstNumber;
        private double secondNumber;
        private string operation;
        private bool textBoxShouldBeCleared;

        private readonly Calculator calculator;

        public MyCalculatorForm()
        {
            InitializeComponent();
            calculator = new Calculator();
            textBox.Text = "0";
            textBoxShouldBeCleared = true;
        }

        private void OnNumberButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (textBoxShouldBeCleared)
            {
                textBox.Clear();
                textBoxShouldBeCleared = false;
            }
            textBox.Text += button.Text;
        }

        private void OnOperationButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (label.Text == "")
            {
                firstNumber = double.Parse(textBox.Text);
                operation = button.Text;
                label.Text = $"{firstNumber} {operation} ";
            }
            else
            {
                if ((label.Text[label.Text.Length - 2] == '+' || label.Text[label.Text.Length - 2] == '-' ||
                    label.Text[label.Text.Length - 2] == '/' || label.Text[label.Text.Length - 2] == '*') &&
                    textBoxShouldBeCleared)
                {
                    label.Text = "";
                    OnOperationButtonClick(sender, e);
                    return;
                }

                secondNumber = double.Parse(textBox.Text);
                firstNumber = calculator.Calculate(operation, firstNumber, secondNumber);

                if (firstNumber == double.PositiveInfinity)
                {
                    textBox.Text = "Cannot divide by zero";
                    textBoxShouldBeCleared = true;
                    label.Text = "";
                    return;
                }

                textBox.Text = $"{firstNumber}";
                operation = button.Text;
                label.Text += $"{secondNumber} {operation} ";
            }
            textBoxShouldBeCleared = true;
        }

        private void OnResultButtonClick(object sender, EventArgs e)
        {
            if (label.Text != "")
            {
                secondNumber = double.Parse(textBox.Text);
                label.Text = "";
            }
            firstNumber = calculator.Calculate(operation, firstNumber, secondNumber);

            if (firstNumber == double.PositiveInfinity)
            {
                textBox.Text = "Cannot divide by zero";
                textBoxShouldBeCleared = true;
                label.Text = "";
                return;
            }

            textBox.Text = $"{firstNumber}";
            textBoxShouldBeCleared = true;
        }

        

        private void OnCommaButtonClick(object sender, EventArgs e)
        {
            if (textBoxShouldBeCleared)
            {
                textBox.Text = "0,";
                textBoxShouldBeCleared = false;
            }
            else
            {
                textBox.Text += ",";
            }
        }

        private void OnBackspaceButtonClick(object sender, EventArgs e)
        {
            if (textBox.Text != "0" && !textBoxShouldBeCleared)
            {
                if (textBox.Text.Remove(textBox.Text.Length - 1) == "")
                {
                    textBox.Text = "0";
                }
                else
                {
                    textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
                }
            }
        }

        private void OnClearButtonClick(object sender, EventArgs e)
        {
            textBox.Text = "0";
            label.Text = "";
            textBoxShouldBeCleared = true;
        }

        private void OnPlusMinusButtonClick(object sender, EventArgs e)
        {
            if (textBox.Text != "0")
            {
                if (textBox.Text[0] != '-')
                {
                    textBox.Text = textBox.Text.Insert(0, "-");
                }
                else
                {
                    textBox.Text = textBox.Text.Remove(0, 1);
                }
            }
        }
    }
}
