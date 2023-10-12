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
                List<Proveedor> proveedores = _proveedorStore.ObtenerTodo();
                return Ok(proveedores);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerProveedor(int id)
        {
            try
            {
                Proveedor proveedor = _proveedorStore.ObtenerPorId(id);

                if (proveedor == null)
                    return NotFound();

                return Ok(proveedor);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarProveedor([FromBody] Proveedor nuevoProveedor)
        {
            try
            {
                _proveedorStore.Agregar(nuevoProveedor);
                List<Proveedor> proveedores = _proveedorStore.ObtenerTodo();
                return Ok(proveedores);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarProveedor(int id, [FromBody] Proveedor proveedorActualizado)
        {
            try
            {
                _proveedorStore.Actualizar(id, proveedorActualizado);
                Proveedor proveedorActualizadoResult = _proveedorStore.ObtenerPorId(id);
                return Ok(proveedorActualizadoResult);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarProveedor(int id)
        {
            try
            {
                Proveedor proveedorEliminado = _proveedorStore.ObtenerPorId(id);

                if (proveedorEliminado == null)
                {
                    return NotFound();
                }

                _proveedorStore.Eliminar(id);
                return Ok(proveedorEliminado);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
