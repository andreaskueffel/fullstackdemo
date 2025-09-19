using LiteDB;

namespace MachineLicenseManagement.WebKeyGen
{
    public class LicenseService
    {
        private readonly LiteDatabase _db;
        private readonly ILiteCollection<LicenseModel> _collection;

        public LicenseService(LiteDatabase db)
        {
            _db = db;
            _collection = _db.GetCollection<LicenseModel>("licenses");
        }

        public IEnumerable<LicenseModel> GetAll() => _collection.FindAll();

        public LicenseModel? GetById(int id) => _collection.FindById(id);

        public ObjectId Create(LicenseModel licence) => _collection.Insert(licence);

        public bool Delete(int id) => _collection.Delete(id);

    }
}
