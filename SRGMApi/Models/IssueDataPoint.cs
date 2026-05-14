namespace SRGMApi.Models
{
    public record IssueDataPoint(int TimeIndex, int Cumulative)
    {
        public override string ToString()
        {
            return "{" + $"{this.TimeIndex}, {this.Cumulative}" + "}";
        }
    }
}
