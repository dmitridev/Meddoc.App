using System;
using System.Collections.Generic;
using System.Text;
using Meddoc.App.Dto;

namespace Meddoc.App.Entity
{
    public class PatientEntity : BaseEntity
    {
        public string AvatarBase64 { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Diagnoz { get; set; }

        public DateTime DateBirth { get; set; }

        public string History { get; set; }

        public PatientWrapper toWrapper()
        {
            return new PatientWrapper
            {
                Name = LastName + " " + Name + " " + MiddleName,
                DateBirth = DateBirth,
                Diagnoz = Diagnoz
            };
        }

        public override string ToString()
        {
            return " " + this.LastName + " " + this.Name + " " + " " + this.MiddleName;
        }
        public override string GetCollectionName() => "patients";
    }
}
