using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace BooksApi.Models
{
    public class Book
    {
        public string Id { get; set; }
        public string BookName { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string Category { get; set; }
        public string Author { get; set; }
    }
}
