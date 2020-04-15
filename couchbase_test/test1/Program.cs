using System;
using System.Threading.Tasks;
using Couchbase;

namespace examples
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await using var cluster = await Cluster.ConnectAsync("couchbase://localhost", "ray", "Harbor5609");
            var bucket = await cluster.BucketAsync("test");
            var collection = bucket.DefaultCollection();

            var upsertResult = await collection.UpsertAsync("my-document", new { Name = "Ted", Age = 31 });
            var getResult = await collection.GetAsync("my-document");
            Console.WriteLine(getResult.ContentAs<dynamic>());

            var queryResult = await cluster.QueryAsync<dynamic>("select \"Hello World\" as greeting", new Couchbase.Query.QueryOptions());
            await foreach (var row in queryResult) {
                Console.WriteLine(row);
            }
        }
    }
}
