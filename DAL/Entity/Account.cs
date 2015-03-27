using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Account
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Имя пользователя")]
        public string Login { get; set; }

        [MinLength(6)]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        public virtual Roles Roles { get; set; }
        public bool ConfirmedEmail { get; set; }
        public string LastName { get; set; }
        public string MidleName { get; set; }
        public string FirstName { get; set; }
    }
}
