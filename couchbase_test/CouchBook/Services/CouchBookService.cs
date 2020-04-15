using System;
using System.Threading.Tasks;
using Couchbase;
using System.Collections.Generic;
using System.Linq;
using BooksApi.Models;
using MongoDB.Driver;

namespace BooksApi.Services
{
    public class CouchBookService
    {
        //private readonly IMongoCollection<Book> _books;
        private Couchbase.KeyValue.ICouchbaseCollection _books;

        public CouchBookService(IBookstoreDatabaseSettings settings)
        {

           Task.Run(async () =>
            {
                try
                {
                    await using var cluster = await Cluster.ConnectAsync(settings.ConnectionString, settings.Username, settings.Password);
                    var bucket = await cluster.BucketAsync(settings.Bucket);
                    var _books = bucket.DefaultCollection();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }

        public List<Book> Get() => _books.GetAsync("document");


        public List<Book> FindByTitle(string title) =>
            _books.Find(book => book.BookName.ToLower().Contains(title.ToLower())).ToList();

        public Book Get(string id) =>
            _books.Find<Book>(book => book.Id == id).FirstOrDefault();

        public Book Create(Book book)
        {
            var result = _books.UpsertAsync("document-key", book);
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
