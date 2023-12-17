using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Service : IBaseEntity
    {
        public int Id { get; set; }
        [Display(Name = "Servise Geliş Tarihi")]
        public DateTime EntryDate { get; set; }//Servise Geliş tarihi

        [Display(Name = "Araç Sorunu"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string VehicleIssue { get; set; }//Araç Sorunu

        [Display(Name = "Servis Ücreti")]
        public decimal ServiceFee { get; set; }//Servis Ücreti

        [Display(Name = "Servisten Çıkış Tarihi")]
        public DateTime ExitDate { get; set; }//Servisden çıkış tarihi

        [Display(Name = "Yapılan İşlemler")]
        public string? PerformedActions { get; set; }//Yapılan işlemler

        [Display(Name = "Garanti Kapsamında Mı?")]
        public bool UnderWarranty { get; set; }//Garanti kapsamında

        [StringLength(15)]
        [Display(Name = "Araç Plaka"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string VehiclePlate { get; set; }//Araç Plaka

        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        [Display(Name = "Marka")]
        public string Brand { get; set; }

        [StringLength(50)]
        public string? Model { get; set; }

        [StringLength(50)]
        [Display(Name = "Kasa Tipi")]
        public string? VehicleBodyType{ get; set; }//KasaTipi
                                                   //
        [StringLength(50)]
        [Display(Name = "Şase No")]
        public string? ChassisNumber { get; set; }//Şase Numarası

        [Required(ErrorMessage = "{0} Boş Bırakılamaz!"), Display(Name = "Notlar")]
        public string Description { get; set;}  
    }
}
