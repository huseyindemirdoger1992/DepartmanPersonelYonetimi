using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DepartmanPersonelYonetimi.Models
{
    public class Departman
    {
        [Key]
        public int DepartmanId { get; set; }

        [DisplayName("Departman Adı")]
        public string DepartmanAd { get; set; }

        public virtual List<Personel> Personel { get; set; }
    }
}