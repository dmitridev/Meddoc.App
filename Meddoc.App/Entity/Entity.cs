using MongoDB.Bson;
using System;

namespace Meddoc.App.Entity
{
    public abstract class BaseEntity
    {
        public ObjectId userId { get; set; }
        
        public ObjectId Id { get; set; }
        public DateTime dateCreate { get; set; }
        public abstract string GetCollectionName();
    }
}
