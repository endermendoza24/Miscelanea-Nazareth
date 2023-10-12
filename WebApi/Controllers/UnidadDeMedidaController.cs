using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Application.Endpoint;

namespace WebApi.Controllers
{
    public class UnidadMedidaController : ApiController
    {
        private AlmacenEntidades<UnidadMedida> _unidadMedidaStore;

        public UnidadMedidaController()
        {
            _unidadMedidaStore = new AlmacenEntidades<UnidadMedida>(u => u.Id);
        }

        [HttpGet]
        public IHttpActionResult ObtenerUnidadesMedida()
        {
            try
            {
                List<UnidadMedida> unidadesMedida = _unidadMedidaStore.ObtenerTodo();
                return Ok(unidadesMedida);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerUnidadMedida(int id)
        {
            try
            {
                UnidadMedida unidadMedida = _unidadMedidaStore.ObtenerPorId(id);

                if (unidadMedida == null)
                    return NotFound();

                return Ok(unidadMedida);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarUnidadMedida([FromBody] UnidadMedida nuevaUnidadMedida)
        {
            try
            {
                _unidadMedidaStore.Agregar(nuevaUnidadMedida);
                List<UnidadMedida> unidadesMedida = _unidadMedidaStore.ObtenerTodo();
                return Ok(unidadesMedida);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarUnidadMedida(int id, [FromBody] UnidadMedida unidadMedidaActualizada)
        {
            try
            {
                _unidadMedidaStore.Actualizar(id, unidadMedidaActualizada);
                UnidadMedida unidadMedidaActualizadaResult = _unidadMedidaStore.ObtenerPorId(id);
                return Ok(unidadMedidaActualizadaResult);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarUnidadMedida(int id)
        {
            try
            {
                UnidadMedida unidadMedidaEliminada = _unidadMedidaStore.ObtenerPorId(id);

                if (unidadMedidaEliminada == null)
                {
                    return NotFound();
                }

                _unidadMedidaStore.Eliminar(id);
                return Ok(unidadMedidaEliminada);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
