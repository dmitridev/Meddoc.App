using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace Meddoc.App.Entity
{
    public class User : BaseEntity
    {
        public string ImageBase64 { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Work { get; set; }
        public override string GetCollectionName() => "users";
    }
}
