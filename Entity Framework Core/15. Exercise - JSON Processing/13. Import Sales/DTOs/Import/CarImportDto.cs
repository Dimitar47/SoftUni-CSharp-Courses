namespace CarDealer.DTOs.Import
{
    public class CarImportDto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public long TraveledDistance { get; set; }
        public List<int> PartsId { get; set; }
    }
}