namespace MachineLicenseManagement.WebKeyGen.Models
{
    public class LicenseModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedByUserId { get; set; }
        public string LicenseKey { get; set; } = string.Empty;
        public int LicensedProductId { get; set; }
        public string MachineId { get; set; } = string.Empty;
        public string Information { get; set; } = string.Empty;
        public string HardwareInformationString { get; set; } = string.Empty;
        public string SelectedHardwareId { get; set; } = string.Empty;

    }
}
