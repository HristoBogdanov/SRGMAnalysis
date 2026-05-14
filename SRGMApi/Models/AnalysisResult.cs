namespace SRGMApi.Models
{
    public record AnalysisResult(
    string BestModel,
    List<ModelResult> Models,
    List<double> PredictionPoints
    );
}
