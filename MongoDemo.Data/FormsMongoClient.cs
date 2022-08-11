using MongoDB.Driver;
using MongoDemo.Data.Entities.Forms;

namespace MongoDemo.Data
{
    public interface IFormsMongoClient : IMongoClient
    {
        IMongoCollection<Form> Forms();
        IMongoCollection<RecordedForm> RecordedForms();
    }

    public class FormsMongoClient : MongoClient, IFormsMongoClient
    {
        public FormsMongoClient(string connectionString)
            : base(connectionString) { }

        public IMongoCollection<Form> Forms()
        {
            return GetDatabase(Databases.Forms).GetCollection<Form>("forms");
        }

        public IMongoCollection<RecordedForm> RecordedForms()
        {
            return GetDatabase(Databases.Forms).GetCollection<RecordedForm>("recorded_forms");
        }
    }
}
