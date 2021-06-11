using Meddoc.App.Entity;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Meddoc.App.Helper
{
    public static class Collection<T> where T : BaseEntity, new()
    {
        public static T Load(long id = 0)
        {
            MongoClient client = new MongoClient(Configuration.Connection);
            var db = client.GetDatabase("meddoc");
            string res = new T().GetCollectionName();
            var mongoCollection = db.GetCollection<T>(res);
            var document = new BsonDocument
            {
                {"id",id },
                {"userId",Configuration.currentUser.Id }
            };
            return mongoCollection.Find(document).FirstOrDefault();
        }

        public static T Load(BsonDocument document)
        {
            MongoClient client = new MongoClient(Configuration.Connection);
            var db = client.GetDatabase("meddoc");
            string res = new T().GetCollectionName();
            var mongoCollection = db.GetCollection<T>(res);

            return mongoCollection.Find(document).FirstOrDefault();
        }
        public static void Save(T @object)
        {
            MongoClient client = new MongoClient(Configuration.Connection);
            var db = client.GetDatabase("meddoc");
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
            try
            {
                var client = new MongoClient(Configuration.Connection);
                var db = client.GetDatabase("meddoc");
                var res = new T().GetCollectionName();
                var mongoCollection = db.GetCollection<T>(res);
                return mongoCollection.Find(template).ToList<T>();
            }
            catch
            {

            }

            return new List<T>();
        }

        public static List<T> List(BsonDocument[] array)
        {
            try
            {
                var client = new MongoClient(Configuration.Connection);
                var db = client.GetDatabase("meddoc");
                var res = new T().GetCollectionName();
                var mongoCollection = db.GetCollection<T>(res).Aggregate<T>(array);
                return mongoCollection.ToList<T>();
            }
            catch
            {

            }

            return new List<T>();
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
            catch
            {

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
            }catch(Exception e)
            {
                //Log error;
            }
        }

        public static long Count()
        {
            MongoClient client = new MongoClient(Configuration.Connection);
            var db = client.GetDatabase("meddoc");
            string name = new T().GetCollectionName();
            return db.GetCollection<T>(name).EstimatedDocumentCount();
        }
    }
}
