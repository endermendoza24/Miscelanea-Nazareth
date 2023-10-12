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
                List<Producto> productos = _productoStore.ObtenerTodo();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerProducto(int id)
        {
            try
            {
                Producto producto = _productoStore.ObtenerPorId(id);

                if (producto == null)
                    return NotFound();

                return Ok(producto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarProducto([FromBody] Producto nuevoProducto)
        {
            try
            {
                _productoStore.Agregar(nuevoProducto);
                List<Producto> productos = _productoStore.ObtenerTodo();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarProducto(int id, [FromBody] Producto productoActualizado)
        {
            try
            {
                _productoStore.Actualizar(id, productoActualizado);
                Producto productoActualizadoResult = _productoStore.ObtenerPorId(id);
                return Ok(productoActualizadoResult);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarProducto(int id)
        {
            try
            {
                Producto productoEliminado = _productoStore.ObtenerPorId(id);

                if (productoEliminado == null)
                {
                    return NotFound();
                }

                _productoStore.Eliminar(id);
                return Ok(productoEliminado);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
