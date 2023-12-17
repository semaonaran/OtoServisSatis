using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer : IBaseEntity
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Display(Name = "Adı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Firstname { get; set; }

        [StringLength(50)]
        [Display(Name = "Soyadı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Lastname { get; set; }

        [StringLength(11),Display(Name = "TC No")]
        public string? TcNo { get; set; }
        
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Email { get; set; }

        [StringLength(500)]
        [Display(Name = "Adres")]
        public string? Address { get; set; }
        [StringLength(15), Display(Name = "Telefon No")]
        public string? PhoneNumber { get; set; } 

        [Display(Name = "Notlar")]
        public string? Description { get; set; }

        [ForeignKey("Vehicle")]
        [Display(Name = "Araç")]
        public int VerticleId { get; set; }
        [Display(Name = "Araç")]
        public virtual Vehicle? Vehicle { get; set; }

        public virtual ICollection<SaleInfo>? SaleInfos { get; set; }

    }
}

