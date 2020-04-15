using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Models
{
    public class BookstoreDatabaseSettings : IBookstoreDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string Bucket { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public interface IBookstoreDatabaseSettings
    {
        string ConnectionString { get; set; }
        string Bucket { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}
