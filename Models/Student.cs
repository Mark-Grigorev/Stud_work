using System;
using System.Collections.Generic;

#nullable disable

namespace StudProject.Models
{
    public partial class Student
    {
        public Student()
        {
            PersonalInformationOfSts = new HashSet<PersonalInformationOfSt>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public int? Groupe { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public long? Phone { get; set; }

        public virtual Groupe GroupeNavigation { get; set; }
        public virtual ICollection<PersonalInformationOfSt> PersonalInformationOfSts { get; set; }
    }
}
