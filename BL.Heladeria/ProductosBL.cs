﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Heladeria
{
   public class ProductosBL
    {
        Contexto _Contexto;
       public BindingList<Producto> ListaProductos { get; set; }

        public ProductosBL()
        {
            _Contexto = new Contexto();
            ListaProductos = new BindingList<Producto>();
           
        }

        public BindingList<Producto> ObtenerProductos()
        {
            _Contexto.Productos.Load();
            ListaProductos = _Contexto.Productos.Local.ToBindingList();
            return ListaProductos;
        }

        public BindingList<Producto> ObtenerProductos(string buscar)
        {

            var resultado = _Contexto.Productos.Where(r => r.Descripcion.Contains(buscar));

            return new BindingList<Producto>(resultado.ToList());
        }

        public Resultado GuardarProducto(Producto producto)
        {
            var resultado = Validar(producto);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }



            _Contexto.SaveChanges();


            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarProducto()
        {
            var nuevoProducto = new Producto();
            ListaProductos.Add(nuevoProducto);
        }

            public bool EliminarProducto(int id)
        {
            foreach (var producto in ListaProductos)
            {
                if (producto.id == id)
                {
                    ListaProductos.Remove(producto);
                    _Contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        private Resultado Validar(Producto producto)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (producto == null)
            {
                resultado.Mensaje = "Agregue un producto valido";
                resultado.Exitoso = false;

                return resultado;
            }

            if (string.IsNullOrEmpty(producto.Descripcion) == true)
            {
                resultado.Mensaje = "Ingrese una descripcion";
                resultado.Exitoso = false;
            
            }
            if (producto.Existencia  < 0) 
            {
                resultado.Mensaje = "La existencia debe ser mayor que cero";
                resultado.Exitoso = false;

            }
            if (producto.CategoriaId == 0)
            {
                resultado.Mensaje = "Seleccione una Categoria";
                resultado.Exitoso = false;
            }
            if (producto.TipoId == 0)
            {
                resultado.Mensaje = "Seleccione un Tipo";
                resultado.Exitoso = false;
            }

            if (producto.Precio < 0)
            {
                resultado.Mensaje = "El precio debe ser mayor que cero";
                resultado.Exitoso = false;

            }

            return resultado;
        }
    }
    public class Producto
    {
        public int id { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public int CategoriaId { get; set; }
        public  Categoria Categoria { get; set; }
        public int TipoId { get; set; }
        public Tipo Tipo { get; set; }
        public bool Activo { get; set; }
        public byte[] foto { get; set; }
    }
   
   
}
