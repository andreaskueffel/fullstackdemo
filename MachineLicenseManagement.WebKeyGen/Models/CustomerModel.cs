using LiteDB;

namespace MachineLicenseManagement.WebKeyGen.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Comment { get; set; }

        public override string ToString()
        {
            return $"{Name} {Comment} ({Address}, {City}, {Country})";
        }
    }
}
