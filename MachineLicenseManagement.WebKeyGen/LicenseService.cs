using LiteDB;
using MachineLicenseManagement.WebKeyGen.Models;

namespace MachineLicenseManagement.WebKeyGen
{
    public class LicenseService
    {
        private readonly LiteDatabase _db;
        private readonly ILiteCollection<LicenseModel> licenseCollection;
        private readonly ILiteCollection<UserModel> userCollection;
        private readonly ILiteCollection<CustomerModel> customerCollection;


        public LicenseService(LiteDatabase db)
        {
            _db = db;
            licenseCollection = _db.GetCollection<LicenseModel>("licenses");
            userCollection = _db.GetCollection<UserModel>("users");
            customerCollection = _db.GetCollection<CustomerModel>("customers");

            if(!customerCollection.FindAll().Any())
            {
                customerCollection.Insert(new CustomerModel { Name = "Default Customer" });
            }
            if (!licenseCollection.FindAll().Any())
            {
                licenseCollection.Insert(new LicenseModel
                {
                    LicenseKey = "XXXX-XXXX-XXXX-XXXX",
                    CreatedAt = DateTime.UtcNow,
                    CreatedByUserId = 1,
                    CustomerId = customerCollection.FindAll().First().Id,
                });
            }
        }

        //Workflow
        //1. Add Customer
        //2. Generate License for Customer
        //3. NicPicker
        //4. Save License


        public IEnumerable<CustomerModel> GetCustomers() => customerCollection.FindAll();

        public IEnumerable<LicenseModel> GetLicenses() => licenseCollection.FindAll();

        public bool CreateCustomer(CustomerModel customer)
        {
            if (customerCollection.Exists(c => c.Name == customer.Name))
                return false;
            customerCollection.Insert(customer);
            return true;
        }

        public bool SaveLicense(LicenseModel license)
        {
            if (licenseCollection.Exists(l => l.LicenseKey == license.LicenseKey && l.Id != license.Id))
                return false;
            if (license.Id == 0)
                licenseCollection.Insert(license);
            else
                licenseCollection.Update(license);
            return true;
        }

        

        public LicenseModel? GetById(int id) => licenseCollection.FindById(id);

        
    }
}
