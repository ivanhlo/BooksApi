using MongoDB.Bson; // para usar objectos Bson
using MongoDB.Bson.Serialization.Attributes; // para usar las anotaciones
using Newtonsoft.Json; // para usar la anotación JsonProperty

namespace BooksApi.Models
{
    public class Book
    {
        [BsonId] // designa a la propiedad Id como la llave primaria del documento
        [BsonRepresentation(BsonType.ObjectId)] // permite pasar los parametros como tipo String en lugar de una estructura ObjectId, ya que Mongo se encarga de convertir de string a ObjectId.
        public string Id { get; set; }

        [BsonElement("Name")] // para que BookName represente la propiedad name de la colección de MongoDB
        [JsonProperty("name")] // representa el nombre de la propiedad en la respuesta JSON serializada de la API web.
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}
