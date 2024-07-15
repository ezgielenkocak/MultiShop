using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductImageUrl { get; set; }

        public string ProductDescription { get; set; }

        public string CategoryId { get; set; }

        [BsonIgnore]
        public Category Category { get; set; }
    }
    #region BsonIgnore Nedir
    /*
      BsonIgnore attribute'ü MongoDB koleksiyonlarında 
    saklanmasını istemediğiniz veya gereksiz bulduğunuz 
    class property'lerini işaretlemek için kullanılır.
    */
    #endregion
}
