using System;
using System.Collections.Generic;

#nullable disable

namespace StudProject.Models
{
    public partial class PersonalInformationOfSt
    {
        public int Id { get; set; }
        public int? Student { get; set; }
        public int? Inn { get; set; }
        public string HomeAdress { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int PositionID { get; set; }

        public virtual Position PositionNavigator { get; set; }
        public virtual Student StudentNavigation { get; set; }
    }
}
