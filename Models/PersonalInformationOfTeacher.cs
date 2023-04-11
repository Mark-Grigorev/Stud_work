using System;
using System.Collections.Generic;

#nullable disable

namespace StudProject.Models
{
    public partial class PersonalInformationOfTeacher
    {
        public int Id { get; set; }
        public int? Teacher { get; set; }
        public int? Inn { get; set; }
        public int? Position { get; set; }
        public long? Phone { get; set; }
        public string HomeAdress { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual Position PositionNavigation { get; set; }
        public virtual Teacher TeacherNavigation { get; set; }
    }
}
