using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Models.Dto
{
    public record Region
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }
    }
}
