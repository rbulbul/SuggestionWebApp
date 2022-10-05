// We added using statement for Bson to global usings

namespace SuggestionAppLibrary.Models;
public class CategoryModel
{
   // BsonId is an identifier 
   [BsonId]
   // This is an objectId
   [BsonRepresentation(BsonType.ObjectId)]
   public string Id { get; set; }
   public string CategoryName { get; set; }
   public string CategoryDescription { get; set; }

}
