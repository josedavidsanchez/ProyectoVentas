//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCTOS
    {
        public PRODUCTOS()
        {
            this.LISTA_PEDIDO = new HashSet<LISTA_PEDIDO>();
        }
    
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string Categoria { get; set; }
        public bool EnOferta { get; set; }
        public string Imagen { get; set; }
    
        public virtual ICollection<LISTA_PEDIDO> LISTA_PEDIDO { get; set; }
    }
}
