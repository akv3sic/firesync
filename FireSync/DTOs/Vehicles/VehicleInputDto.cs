namespace FireSync.DTOs.Vehicles
{
    public class VehicleInputDto
    {
        public string LicensePlate { get; set; } = string.Empty;
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public short YearOfManufacture { get; set; } = 0;
    }
}
