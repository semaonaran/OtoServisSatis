using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Vehicle : IBaseEntity
    {
        public int Id { get; set; }

        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        [Display(Name = "Renk")]
        public string Color { get; set; }

        [Display(Name = "Fiyat")]
        public decimal Price { get; set;}

        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        [Display(Name = "Modeli")]
        public string Model { get; set;}

        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        [Display(Name = "Kasa Tipi")]
        public string VehicleBodyType{ get; set; }//KasaTipi

        [Display(Name = "Model Yılı")]
        public int ModelYear { get; set;}

        [Display(Name = "Satışta Mı?")]
        public bool Sale { get; set; } //SatistaMi

        [Display(Name = "Notlar"),Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Description { get; set;}

        [ForeignKey("Brand") ]
        [Display(Name = "Marka Adı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public int BrandId { get; set; }
        [Display(Name = "Marka Adı")]
        public virtual Brand? Brand { get; set; }

        public virtual ICollection<Customer>? Customers { get; set; }
        public virtual ICollection<SaleInfo>? SaleInfos { get; set; }

    }
}
