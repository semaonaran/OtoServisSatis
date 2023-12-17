using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User : IBaseEntity
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Adı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Firstname { get; set; }
        [StringLength(50), Display(Name = "Soyadı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Lastname { get; set; }

        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Email { get; set; }

        [StringLength(20),Display(Name = "Telefon No")]
        public string ?PhoneNumber { get; set; }

        [StringLength(50), Display(Name = "Kullanıcı Adı")]
        public string ?UserName { get; set; }

        [Display(Name = "Şifre"), StringLength(50)]
        [Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Password { get; set; }

        [Display(Name = "Aktif Mi?")]
        public bool ActiveRatio { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime UploadDate { get; set; } = DateTime.Now;  //eklenme tarihi

        [ForeignKey("Role"), Display(Name = "Kullanıcı Rolü"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]        
        public int RoleId { get; set; }
        [Display(Name = "Kullanıcı Rolü")]
        public virtual Role? Role { get; set; }
    }
}
