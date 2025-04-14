namespace WPFCalculatorApp.Models
{
    public class AddOperation : IOperation
    {
        public double Execute(double a, double b) => a + b;
    }
}
