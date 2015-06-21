using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ProductoController : Controller
    {
        //
        //GET: /Producto/
        DAL.VENTASserverdbEntities entidades = new DAL.VENTASserverdbEntities();
        public ActionResult Index()   
        {
            var listaProductos = entidades.PRODUCTOS;
            List<Producto> productos = new List<Producto>();
            foreach (var item in listaProductos)
            {
                Producto producto = new Producto();
                producto.Codigo = item.Codigo;
                producto.Nombre = item.Nombre;
                producto.Descripcion = item.Descripcion;
                producto.Precio = item.Precio;
                producto.Categoria = item.Categoria;
                producto.EnOferta = item.EnOferta;
                producto.Cantidad = item.Cantidad;
                productos.Add(producto);
            }
            return View(productos);
        }

    }
}
