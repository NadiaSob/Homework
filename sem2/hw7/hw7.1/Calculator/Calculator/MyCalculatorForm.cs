using System;
using System.Windows.Forms;

namespace homework
{
    public partial class MyCalculatorForm : Form
    {
        private Calculator calculator;

        public MyCalculatorForm()
        {
            InitializeComponent();

            calculator = new Calculator();
            textBox.Text = "0";
        }

        private void OnNumberButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            textBox.Text = calculator.NumberButtonClick(button.Text, textBox.Text);
        }

        private void OnOperationButtonClick(object sender, EventArgs e)
        {
            string button = "";
            if (e is KeyPressEventArgs e1)
            {
                button = e1.KeyChar.ToString();
            }
            else if (sender is Button sender1)
            {
                button = sender1.Text;
            }

            (label.Text, textBox.Text) = calculator.OperationButtonClick(button, label.Text, textBox.Text);
        }

        private void OnResultButtonClick(object sender, EventArgs e)
            => (label.Text, textBox.Text) = calculator.ResultButtonClick(label.Text, textBox.Text);

        private void OnCommaButtonClick(object sender, EventArgs e)
            => textBox.Text = calculator.CommaButtonClick(textBox.Text);

        private void OnBackspaceButtonClick(object sender, EventArgs e)
            => textBox.Text = calculator.BackspaceButtonClick(textBox.Text);

        private void OnClearButtonClick(object sender, EventArgs e) 
            => (label.Text, textBox.Text) = calculator.ClearButtonClick(label.Text, textBox.Text);

        private void OnPlusMinusButtonClick(object sender, EventArgs e)
            => textBox.Text = calculator.PlusMinusButtonClick(textBox.Text);

        private void OnTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                if (calculator.TextBoxShouldBeCleared)
                {
                    textBox.Clear();
                    calculator.TextBoxShouldBeCleared = false;
                }
                return;
            }

            if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/')
            {
                OnOperationButtonClick(sender, e);
                e.Handled = true;
                return;
            }
            
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                OnCommaButtonClick(sender, e);
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '=' || e.KeyChar == (char)Keys.Enter)
            {
                OnResultButtonClick(sender, e);
                e.Handled = true;
                return;
            }

            if (e.KeyChar == (char)Keys.Back)
            {
                OnBackspaceButtonClick(sender, e);
                e.Handled = true;
                return;
            }

            if (e.KeyChar == (char)Keys.Escape)
            {
                OnClearButtonClick(sender, e);
                e.Handled = true;
                return;
            }

            e.Handled = true;
        }
    }
}
