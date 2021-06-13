using Meddoc.App.Entity;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meddoc.App.Helper
{
    public static class Collection<T> where T : BaseEntity, new()
    {

        public static async Task<T> Load(BsonDocument document)
        {
            MongoClient client = new MongoClient(Configuration.Connection);
            var db = client.GetDatabase("meddoc");
            string res = new T().GetCollectionName();
            var mongoCollection = db.GetCollection<T>(res);

            return await mongoCollection.Find(document).FirstOrDefaultAsync();
        }


        public static void Save(T @object)
        {
            MongoClient client = new MongoClient(Configuration.Connection);
            var db = client.GetDatabase("meddoc");
            if (Configuration.currentUser != null)
                @object.userId = Configuration.currentUser.Id;
            var mongoCollection = db.GetCollection<T>(@object.GetCollectionName());
            var filter = Builders<T>.Filter.Eq(s => s.Id, @object.Id);

            mongoCollection.ReplaceOne(filter, @object, new ReplaceOptions
            {
                IsUpsert = true
            }
            );
        }

        public static List<T> List(BsonDocument template)
        {
            template.Add("userId", Configuration.currentUser.Id);
            var client = new MongoClient(Configuration.Connection);
            var db = client.GetDatabase("meddoc");
            var res = new T().GetCollectionName();
            var mongoCollection = db.GetCollection<T>(res);
            return mongoCollection.Find(template).ToList<T>();
        }

        public static async Task<IAsyncCursor<T>> ListAsync(BsonDocument template)
        {
            template.Add("userId", Configuration.currentUser.Id);
            var client = new MongoClient(Configuration.Connection);
            var db = client.GetDatabase("meddoc");
            var res = new T().GetCollectionName();
            var mongoCollection = db.GetCollection<T>(res);
            return await mongoCollection.FindAsync(template);                                                            
        }

        public static List<T> List(FilterDefinition<T> definition)
        {
            try
            {
                var client = new MongoClient(Configuration.Connection);
                var db = client.GetDatabase("meddoc");
                var res = new T().GetCollectionName();
                var mongoCollection = db.GetCollection<T>(res);
                return mongoCollection.Find(definition).ToList<T>();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            return new List<T>();
        }

        public static void Del(T @object)
        {
            MongoClient client = new MongoClient(Configuration.Connection);
            var db = client.GetDatabase("meddoc");
            string name = @object.GetCollectionName();
            var filter = Builders<T>.Filter.Eq(obj => obj.Id, @object.Id);
            try
            {
                db.GetCollection<T>(name).FindOneAndDelete<T>(filter);
            }
            catch (Exception e)
            {
                //Log error;
            }
        }

        public static long Count(BsonDocument template)
        {
            MongoClient client = new MongoClient(Configuration.Connection);
            var db = client.GetDatabase("meddoc");
            string name = new T().GetCollectionName();
            return db.GetCollection<T>(name).Find(template).CountDocuments();
        }
    }
}
