namespace InvestmentAnalysis.Core.Domain
{
    public record class Land
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Unieke 2 digit code (ISO)
        /// </summary>
        /// <remarks>Alternatieve unieke sleutel</remarks>
        public string LandCode { get; set; }
        public string Naam_NL { get; set; }
        public string Naam_FR { get; set; }
        public string Naam_EN { get; set; }
    }
}