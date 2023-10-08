using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Application.Endpoint;

namespace WebApi.Controllers
{
    public class ProductoController : ApiController
    {
        private AlmacenEntidades<Producto> _productoStore;

        public ProductoController()
        {
            _productoStore = new AlmacenEntidades<Producto>(p => p.Id);
        }

        [HttpGet]
        public IHttpActionResult ObtenerProductos()
        {
            try
            {
                // Obtiene la lista de todos los productos
                List<Producto> productos = _productoStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de productos
                return Ok(productos);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerProducto(int id)
        {
            try
            {
                // Intenta obtener un producto por su ID
                Producto producto = _productoStore.ObtenerPorId(id);

                if (producto == null)
                    // Si no se encuentra el producto, devuelve una respuesta NotFound
                    return NotFound();

                // Si se encuentra el producto, devuelve una respuesta Ok con el producto
                return Ok(producto);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarProducto([FromBody] Producto nuevoProducto)
        {
            try
            {
                // Agrega un nuevo producto
                _productoStore.Agregar(nuevoProducto);

                // Obtiene la lista actualizada de productos
                List<Producto> productos = _productoStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de productos
                return Ok(productos);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarProducto(int id, [FromBody] Producto productoActualizado)
        {
            try
            {
                // Intenta actualizar el producto por su ID
                _productoStore.Actualizar(id, productoActualizado);

                // Obtiene la lista actualizada de productos
                List<Producto> productos = _productoStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de productos
                return Ok(productos);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarProducto(int id)
        {
            try
            {
                // Intenta eliminar el producto por su ID
                _productoStore.Eliminar(id);

                // Obtiene la lista actualizada de productos
                List<Producto> productos = _productoStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de productos
                return Ok(productos);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }
    }
}
