namespace Services.IServices
{
    public interface IBisectionCalculator
    {
        string Expression { get; set; }

        double BeginInterval { get; set; }

        double EndInterval { get; set; }

        double ErrorExpression { get; set; }

        CalculateEventArgs Calculate();
    }
}