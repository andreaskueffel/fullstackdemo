namespace MachineLicenseManagement.WebKeyGen
{
    public class LicenseModel
    {
        public string Key { get; set; }
        public int ProductId { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
