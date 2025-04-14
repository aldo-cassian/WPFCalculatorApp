namespace WPFCalculatorApp.Models
{
    public class MulOperation : IOperation
    {
        public double Execute(double a, double b) => a * b;
    }
}
