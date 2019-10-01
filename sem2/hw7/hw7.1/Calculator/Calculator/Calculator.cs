using System;

namespace homework
{
    /// <summary>
    /// Class that do calculation and modifies label and textBox. 
    /// </summary>
    public class Calculator
    {
        public Calculator()
        {
            TextBoxShouldBeCleared = true;
        }

        private double firstNumber;
        private double secondNumber;
        private string operation;
        public bool TextBoxShouldBeCleared { get; set; }

        /// <summary>
        /// Do the operation with two numbers.
        /// </summary>
        /// <param name="operation">Symbol of the operation.</param>
        /// <param name="firstNumber">First number of the expression.</param>
        /// <param name="secondNumber">Second number of the expression.</param>
        /// <returns>Result of the operation.</returns>
        public double Calculate()
        {
            switch (operation)
            {
                case "+":
                    return firstNumber + secondNumber;
                case "-":
                    return firstNumber - secondNumber;
                case "*":
                    return firstNumber * secondNumber;
                case "/":
                    return firstNumber / secondNumber;
                default:
                    throw new FormatException("Invalid symbol");
            }
        }

        /// <summary>
        /// Adds given number to textBox.
        /// </summary>
        /// <param name="button">Number to add.</param>
        /// <param name="textBoxText">Text of textBox.</param>
        /// <returns>New text of textBox.</returns>
        public string NumberButtonClick(string button, string textBoxText)
        {
            if (TextBoxShouldBeCleared)
            {
                TextBoxShouldBeCleared = false;
                return button;
            }
            return textBoxText + button;
        }

        /// <summary>
        /// Adds given operation sign on label or does the operation and modifies textBox and label.
        /// </summary>
        /// <param name="button">Given operation sign.</param>
        /// <param name="labelText">Text of label.</param>
        /// <param name="textBoxText">Text of textBox.</param>
        /// <returns>New text of label and textBox.</returns>
        public (string, string) OperationButtonClick(string button, string labelText, string textBoxText)
        {
            if (labelText == "")
            {
                firstNumber = double.Parse(textBoxText);
                operation = button;
                labelText = $"{firstNumber} {operation} ";
            }
            else
            {
                if ((labelText[labelText.Length - 2] == '+' || labelText[labelText.Length - 2] == '-' ||
                    labelText[labelText.Length - 2] == '/' || labelText[labelText.Length - 2] == '*') &&
                    TextBoxShouldBeCleared)
                {
                    labelText = "";
                    OperationButtonClick(button, labelText, textBoxText);
                    return (labelText, textBoxText);
                }

                secondNumber = double.Parse(textBoxText);
                firstNumber = Calculate();

                if (firstNumber == double.PositiveInfinity)
                {
                    textBoxText = "Cannot divide by zero";
                    TextBoxShouldBeCleared = true;
                    labelText = "";
                    return (labelText, textBoxText);
                }

                textBoxText = $"{firstNumber}";
                operation = button;
                labelText += $"{secondNumber} {operation} ";
            }
            TextBoxShouldBeCleared = true;
            return (labelText, textBoxText);
        }

        /// <summary>
        /// Calculates the expression.
        /// </summary>
        /// <param name="labelText">Text of label.</param>
        /// <param name="textBoxText">Text of textBox.</param>
        /// <returns>New text of label and textBox.</returns>
        public (string, string) ResultButtonClick(string labelText, string textBoxText)
        {
            if (labelText != "" && !TextBoxShouldBeCleared)
            {
                secondNumber = double.Parse(textBoxText);
                labelText = "";
            }
            else
            {
                return (labelText, textBoxText);
            }

            firstNumber = Calculate();

            if (firstNumber == double.PositiveInfinity)
            {
                textBoxText = "Cannot divide by zero";
                TextBoxShouldBeCleared = true;
                labelText = "";
                return (labelText, textBoxText);
            }

            textBoxText = $"{firstNumber}";
            TextBoxShouldBeCleared = true;
            return (labelText, textBoxText);
        }

        /// <summary>
        /// Adds comma on the textBox.
        /// </summary>
        /// <param name="textBoxText">Text of textBox.</param>
        /// <returns>New text of textBox.</returns>
        public string CommaButtonClick(string textBoxText)
        {
            if (textBoxText[textBoxText.Length - 1] == ',')
            {
                return textBoxText;
            }

            if (TextBoxShouldBeCleared)
            {
                TextBoxShouldBeCleared = false;
                return "0,";
            }
            else
            {
                return textBoxText + ",";
            }
        }

        /// <summary>
        /// Deletes the last symbol on the textBox.
        /// </summary>
        /// <param name="textBoxText">Text of textBox.</param>
        /// <returns>New text of textBox.</returns>
        public string BackspaceButtonClick(string textBoxText)
        {
            if (textBoxText != "0" && !TextBoxShouldBeCleared)
            {
                if (textBoxText.Remove(textBoxText.Length - 1) == "")
                {
                    return "0";
                }
                else
                {
                    return textBoxText.Remove(textBoxText.Length - 1);
                }
            }
            return textBoxText;
        }

        /// <summary>
        /// Clears textBox and label.
        /// </summary>
        /// <param name="labelText">Text of label.</param>
        /// <param name="textBoxText">Text of textBox.</param>
        /// <returns>New text of label and textBox.</returns>
        public (string, string) ClearButtonClick(string labelText, string textBoxText)
        {
            firstNumber = 0;
            secondNumber = 0;
            TextBoxShouldBeCleared = true;

            return ("", "0");
        }

        /// <summary>
        /// Adds minus at the begining of the textBox or removes it.
        /// </summary>
        /// <param name="textBoxText">Text of textBox.</param>
        /// <returns>New text of textBox.</returns>
        public string PlusMinusButtonClick(string textBoxText)
        {
            if (textBoxText != "0")
            {
                if (textBoxText[0] != '-')
                {
                    return textBoxText.Insert(0, "-");
                }
                else
                {
                    return textBoxText.Remove(0, 1);
                }
            }
            return textBoxText;
        }
    }
}
