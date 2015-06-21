using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace WebApplication.Models
{
    public class ModeloProducto
    {
        [Display(Name = "Codigo   ")]
        [StringLength(60)]
        public string Codigo { get; set; }
        [Display(Name = "Nombre   ")]
        [StringLength(60, MinimumLength = 3)]
        public string Nombre { get; set; }

        [Display(Name = "Descripcion")]
        [StringLength(100)]
        public string Descripcion { get; set; }

        [Display(Name = "Precio")]
        [Range(1, 100, ErrorMessage = "El precio debe estar entre 1 y 100")]
        [DataType(DataType.Currency, ErrorMessage = "El valor debe ser decimal")]
        public Nullable<double> Precio { get; set; }

        [Display(Name = "Categoria    ")]
        [StringLength(50)]
        public string Categoria { get; set; }

        [Display(Name = "Oferta      ")]
        [StringLength(20, MinimumLength = 3)]
        public bool EnOferta { get; set; }

        [Display(Name = "Descripcion de la oferta")]
        [StringLength(60, MinimumLength = 3)]
        public string DescripcionOferta { get; set; }
    }

}