using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meddoc.App.Entity
{
    public class Note : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public ObjectId PatientId { get; set; }
        public override string GetCollectionName() => "notes";
    }
}
