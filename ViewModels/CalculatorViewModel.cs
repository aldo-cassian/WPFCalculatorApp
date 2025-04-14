using System;
using System.Collections.Generic;
using System.Windows.Input;
using WPFCalculatorApp.Commands;
using WPFCalculatorApp.Logging;
using WPFCalculatorApp.Models;

namespace WPFCalculatorApp.ViewModels
{
    public class CalculatorViewModel : ViewModelBase
    {
        #region Members
        private string display = "0";
        private double firstOperand;
        private string operation;
        private bool isNewInput = true;

        private readonly Dictionary<string, IOperation> operations;

        public string Display
        {
            get => display;
            set
            {
                display = value;
                OnPropertyChanged(nameof(Display));
            }
        }

        public ICommand DigitCommand { get; }
        public ICommand OperationCommand { get; }
        public ICommand EqualCommand { get; }
        public ICommand ClearCommand { get; }
        #endregion

        public CalculatorViewModel()
        {
            operations = new Dictionary<string, IOperation>
            {
                { "+", new AddOperation() },
                { "-", new SubOperation() },
                { "*", new MulOperation() },
                { "/", new DivOperation() }
            };

            DigitCommand = new RelayCommand(OnDigitButtonClicked);
            OperationCommand = new RelayCommand(OnOperatorButtonClicked);
            EqualCommand = new RelayCommand(OnEqualButtonClicked);
            ClearCommand = new RelayCommand(x => OnClearButtonClicked());
        }

        private void OnDigitButtonClicked(object param)
        {
            string digit = param.ToString();

            if (isNewInput)
            {
                Display = digit;
                isNewInput = false;
                return;
            }

            string currentOperand = GetCurrentOperand();
            int decimalIndex = currentOperand.LastIndexOf('.');

            if (decimalIndex >= 0)
            {
                int digitsAfterDecimal = currentOperand.Length - decimalIndex - 1;

                if (digitsAfterDecimal >= 5 && char.IsDigit(digit, 0))
                    return;
            }

            if (digit == "." && currentOperand.Contains("."))
                return;

            Display += digit;
        }

        private string GetCurrentOperand()
        {
            int lastOpIndex = Math.Max(
                Math.Max(Display.LastIndexOf('+'), Display.LastIndexOf('-')),
                Math.Max(Display.LastIndexOf('*'), Display.LastIndexOf('/'))
            );

            return lastOpIndex >= 0 ? Display.Substring(lastOpIndex + 1) : Display;
        }

        private void OnOperatorButtonClicked(object param)
        {
            if (!string.IsNullOrWhiteSpace(Display))
            {
                if (double.TryParse(Display, out firstOperand))
                {
                    operation = param.ToString();
                    Display += operation;
                    isNewInput = false;
                }
            }
        }

        private void OnEqualButtonClicked(object param)
        {
            if (string.IsNullOrWhiteSpace(operation)) 
                return;

            int opIndex = Display.LastIndexOf(operation);
            if (opIndex == -1 || opIndex == Display.Length - 1) 
                return;

            string rightPart = Display.Substring(opIndex + 1);
            if (!double.TryParse(rightPart, out double secondOperand)) 
                return;

            if (operations.TryGetValue(operation, out var command))
            {
                double result = command.Execute(firstOperand, secondOperand);
                LogHelper.Log($"{firstOperand} {operation} {secondOperand} = {result}");

                Display = result.ToString();
                isNewInput = true;
                operation = null;
            }        
        }

        private void OnClearButtonClicked()
        {
            Display = "0";
            firstOperand = 0;
            operation = null;
            isNewInput = true;
        }

        private string FormatResult(double result)
        {
            return result.ToString("0.#####");
        }
    }
}