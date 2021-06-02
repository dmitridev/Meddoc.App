using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace Meddoc.App.Entity
{
    public class ReceptionEntity : BaseEntity
    {
        public ObjectId PatientEntity { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Info { get; set; }
        public override string GetCollectionName() => "receptions";
    }
}
