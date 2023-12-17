using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SaleInfo : IBaseEntity
    {
        public int Id { get; set; }

        [Display(Name = "Satış Fiyatı")]
        public decimal SalePrice { get; set; }

        [Display(Name = "Satış Tarihi")]
        public DateTime SaleDate { get; set; }

        [ForeignKey("Vehicle")]
        [Display(Name = "Araç")]
        public int VerticleId { get; set; }

        [Display(Name = "Araç")]
        public virtual Vehicle? Vehicle { get; set; }

        [ForeignKey("Customer")]
        [Display(Name = "Müşteri")]
        public int CustomerId { get; set; }
        [Display(Name = "Müşteri")]
        public virtual Customer? Customer { get; set; }
    }
}
