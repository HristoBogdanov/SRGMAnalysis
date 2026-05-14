namespace SRGMApi.Models
{
    public record ModelResult(
    string ModelName,
    double AIC,
    double BIC,
    double AICc,
    double RSquared,
    double AdjustedRSquared,
    Dictionary<string, double> Parameters
    );
}
