namespace BooksApi.Models
{
    /*
     * almacena los valores de la propiedad BookstoreDatabaseSettings configurados en el
     * archivo appsettings.json. Los nombres de las propiedades tanto en JSON como en C#
     * se nombraron igual para facilitar el proceso de mapeo.
     */
    public class BookstoreDatabaseSettings : IBookstoreDatabaseSettings
    {
        public string BooksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IBookstoreDatabaseSettings
    {
        string BooksCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}