﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SuperEntities : DbContext
    {
        public SuperEntities()
            : base("name=SuperEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<compra> compra { get; set; }
        public virtual DbSet<detalle_compra> detalle_compra { get; set; }
        public virtual DbSet<detalle_venta> detalle_venta { get; set; }
        public virtual DbSet<producto> producto { get; set; }
        public virtual DbSet<proveedor> proveedor { get; set; }
        public virtual DbSet<rol> rol { get; set; }
        public virtual DbSet<venta> venta { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
    
        public virtual int sp_regisrarUsuario(string correo, string clave, Nullable<int> idrol, string nombre, string tipo_documento, string num_documento, string direccion, string telefono, ObjectParameter registrado, ObjectParameter mensaje)
        {
            var correoParameter = correo != null ?
                new ObjectParameter("correo", correo) :
                new ObjectParameter("correo", typeof(string));
    
            var claveParameter = clave != null ?
                new ObjectParameter("clave", clave) :
                new ObjectParameter("clave", typeof(string));
    
            var idrolParameter = idrol.HasValue ?
                new ObjectParameter("idrol", idrol) :
                new ObjectParameter("idrol", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var tipo_documentoParameter = tipo_documento != null ?
                new ObjectParameter("tipo_documento", tipo_documento) :
                new ObjectParameter("tipo_documento", typeof(string));
    
            var num_documentoParameter = num_documento != null ?
                new ObjectParameter("num_documento", num_documento) :
                new ObjectParameter("num_documento", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("direccion", direccion) :
                new ObjectParameter("direccion", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_regisrarUsuario", correoParameter, claveParameter, idrolParameter, nombreParameter, tipo_documentoParameter, num_documentoParameter, direccionParameter, telefonoParameter, registrado, mensaje);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_validarUsuario(string correo, string clave, Nullable<int> idrol)
        {
            var correoParameter = correo != null ?
                new ObjectParameter("correo", correo) :
                new ObjectParameter("correo", typeof(string));
    
            var claveParameter = clave != null ?
                new ObjectParameter("clave", clave) :
                new ObjectParameter("clave", typeof(string));
    
            var idrolParameter = idrol.HasValue ?
                new ObjectParameter("idrol", idrol) :
                new ObjectParameter("idrol", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_validarUsuario", correoParameter, claveParameter, idrolParameter);
        }
    }
}
