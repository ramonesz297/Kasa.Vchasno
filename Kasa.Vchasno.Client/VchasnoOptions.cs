namespace Kasa.Vchasno.Client
{
    public class VchasnoOptions
    {
        public string Token { get; set; } = null!;

        public string Device { get; set; } = null!;

        public string? Source { get; set; }
    }
}