using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
   public class Roles
    {
        [Key]
        public int RoleID { get; set; }
        public string NameRoles { get; set; }
       public Roles()
        {
            this.RoleID = RoleID;
            this.NameRoles = NameRoles;
        }

       public Roles(int RoleID, string NameRoles)
        {
            this.RoleID = RoleID;
            this.NameRoles = NameRoles;
        }

    }
}
