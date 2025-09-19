using LiteDB;

namespace MachineLicenseManagement.WebKeyGen
{
    public class LiteDbConfig
    {
        public static LiteDatabase CreateDatabase()
        {
            return new LiteDatabase(@"Filename=licences.db;Connection=shared");
        }

    }
}
