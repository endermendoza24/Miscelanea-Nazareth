using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Application.Endpoint;

namespace WebApi.Controllers
{
    public class ProveedorController : ApiController
    {
        private AlmacenEntidades<Proveedor> _proveedorStore;

        public ProveedorController()
        {
            _proveedorStore = new AlmacenEntidades<Proveedor>(p => p.Id);
        }

        [HttpGet]
        public IHttpActionResult ObtenerProveedores()
        {
            try
            {
                // Obtiene la lista de todos los proveedores
                List<Proveedor> proveedores = _proveedorStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de proveedores
                return Ok(proveedores);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerProveedor(int id)
        {
            try
            {
                // Intenta obtener un proveedor por su ID
                Proveedor proveedor = _proveedorStore.ObtenerPorId(id);

                if (proveedor == null)
                    // Si no se encuentra el proveedor, devuelve una respuesta NotFound
                    return NotFound();

                // Si se encuentra el proveedor, devuelve una respuesta Ok con el proveedor
                return Ok(proveedor);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarProveedor([FromBody] Proveedor nuevoProveedor)
        {
            try
            {
                // Agrega un nuevo proveedor
                _proveedorStore.Agregar(nuevoProveedor);

                // Obtiene la lista actualizada de proveedores
                List<Proveedor> proveedores = _proveedorStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de proveedores
                return Ok(proveedores);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarProveedor(int id, [FromBody] Proveedor proveedorActualizado)
        {
            try
            {
                // Intenta actualizar el proveedor por su ID
                _proveedorStore.Actualizar(id, proveedorActualizado);

                // Obtiene la lista actualizada de proveedores
                List<Proveedor> proveedores = _proveedorStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de proveedores
                return Ok(proveedores);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarProveedor(int id)
        {
            try
            {
                // Intenta eliminar el proveedor por su ID
                _proveedorStore.Eliminar(id);

                // Obtiene la lista actualizada de proveedores
                List<Proveedor> proveedores = _proveedorStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de proveedores
                return Ok(proveedores);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }
    }
}
