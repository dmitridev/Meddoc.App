using System;
using MongoDB.Bson;

namespace Meddoc.App.Entity
{
    public class PatientNote : BaseEntity
    {
        public ObjectId PatientId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public override string GetCollectionName() => "patient_notes";
    }
}
