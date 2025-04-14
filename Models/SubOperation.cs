namespace WPFCalculatorApp.Models
{
    public class SubOperation : IOperation
    {
        public double Execute(double a, double b) => a - b;
    }
}
