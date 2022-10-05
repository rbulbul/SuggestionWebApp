using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace SuggestionAppLibrary.DataAccess;
public class DbConnection
{
   // These are set of connection to our database and we have called that "devsuggestionapp". It will create for us to first time we connect
   private readonly IConfiguration _config;
   private readonly IMongoDatabase _db;
   private string _connectionId = "MongoDB";
   public string DbName { get; private set; }
   public string CategoryCollectionName { get; private set; } = "categories";
   public string StatusCollectionName { get; private set; } = "statuses";
   public string UserCollectionName { get; private set; } = "users";
   public string SuggestionCollectionName { get; private set; } = "suggestions";
   // We need to connect to our collection outside of this db connection
   public MongoClient Client { get; private set; }
   public IMongoCollection<CategoryModel> CategoryCollection { get;private set; }
   public IMongoCollection<StatusModel> StatusCollection { get;private set; }
   public IMongoCollection<UserModel> UserCollection { get;private set; }
   public IMongoCollection<SuggestionModel> SuggestionCollection { get;private set; }

   // We need a constructor gets the configuration
   public DbConnection(IConfiguration config)
   {
      _config = config;
      // Created new client
      Client = new MongoClient(_config.GetConnectionString(_connectionId));
      // Connection to our database -> grab databasename -> connect to that db
      DbName = _config[key: "DatabaseName"];
      _db = Client.GetDatabase(DbName);

      // connection to all four our collection
      CategoryCollection = _db.GetCollection<CategoryModel>(CategoryCollectionName);
      StatusCollection = _db.GetCollection<StatusModel>(StatusCollectionName);
      UserCollection = _db.GetCollection<UserModel>(UserCollectionName);
      SuggestionCollection = _db.GetCollection<SuggestionModel>(SuggestionCollectionName);
   }
}
