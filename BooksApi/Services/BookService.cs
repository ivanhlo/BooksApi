using System.Collections.Generic;
using System.Linq;
using BooksApi.Models;
using MongoDB.Driver; // para ejecutar operaciones CRUD

namespace BooksApi.Services
{
    public class BookService
    {
        /*
         * Propiedad y método del constructor para hacer la injección de dependencia (DI)
         */

        private readonly IMongoCollection<Book> _books;

        public BookService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString); // Lee la instancia del servidor para ejecutar operaciones de base de datos
            var database = client.GetDatabase(settings.DatabaseName); // Representa la base de datos Mongo para ejecutar operaciones

            _books = database.GetCollection<Book>(settings.BooksCollectionName);

            /*
             * El método GetCollection<TDocument>(collection) retorna un objeto MongoCollection que
             * representa a la colección, donde:
             * 
             * collection representa el nombre de la colección
             * TDocument representa al tipo de objeto CLR almacenado en la colección
             */
        }

        /*
         * Métodos CRUD
         */

        public List<Book> Get() =>
            _books.Find(book => true).ToList();

        public Book Get(string id) =>
            _books.Find<Book>(book => book.Id == id).FirstOrDefault();

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, Book bookIn) =>
            _books.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Book bookIn) =>
            _books.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _books.DeleteOne(book => book.Id == id);
    }
}
