//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppVentaSuper
{
    using System;
    using System.Collections.Generic;
    
    public partial class detalle_compra
    {
        public int iddetalle_compra { get; set; }
        public int idcompra { get; set; }
        public int idproducto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
    
        public virtual compra compra { get; set; }
        public virtual producto producto { get; set; }
    }
}
