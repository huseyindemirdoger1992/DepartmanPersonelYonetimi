using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DepartmanPersonelYonetimi.Models
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }

        [DisplayName("Personel Adı")]
        public string PersonelAd { get; set; }

        [DisplayName("Personel Soyadı")]

        public string PersonelSoyad { get; set; }

        public int DepartmanId { get; set; }
        public virtual Departman Departman { get; set; }
    }
}