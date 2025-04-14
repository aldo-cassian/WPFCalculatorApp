namespace WPFCalculatorApp.Models
{
    public class DivOperation : IOperation
    {
        public double Execute(double a, double b) => b != 0 ? a / b : 0;
    }
}
