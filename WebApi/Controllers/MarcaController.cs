using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Application.Endpoint;

namespace WebApi.Controllers
{
    public class MarcaController : ApiController
    {
        private AlmacenEntidades<Marca> _marcaStore;

        public MarcaController()
        {
            _marcaStore = new AlmacenEntidades<Marca>(m => m.Id);
        }

        [HttpGet]
        public IHttpActionResult ObtenerMarcas()
        {
            try
            {
                // Obtiene la lista de todas las marcas
                List<Marca> marcas = _marcaStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de marcas
                return Ok(marcas);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerMarca(int id)
        {
            try
            {
                // Intenta obtener una marca por su ID
                Marca marca = _marcaStore.ObtenerPorId(id);

                if (marca == null)
                    // Si no se encuentra la marca, devuelve una respuesta NotFound
                    return NotFound();

                // Si se encuentra la marca, devuelve una respuesta Ok con la marca
                return Ok(marca);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarMarca([FromBody] Marca nuevaMarca)
        {
            try
            {
                // Agrega una nueva marca
                _marcaStore.Agregar(nuevaMarca);

                // Obtiene la lista actualizada de marcas
                List<Marca> marcas = _marcaStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de marcas
                return Ok(marcas);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarMarca(int id, [FromBody] Marca marcaActualizada)
        {
            try
            {
                // Intenta actualizar la marca por su ID
                _marcaStore.Actualizar(id, marcaActualizada);

                // Obtiene la marca actualizada
                Marca marcaActualizadaResult = _marcaStore.ObtenerPorId(id); // Cambio de nombre de la variable

                // Devuelve una respuesta Ok con la marca actualizada
                return Ok(marcaActualizadaResult);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }



        [HttpDelete]
        public IHttpActionResult EliminarMarca(int id)
        {
            try
            {
                // Intenta eliminar la marca por su ID
                Marca marcaEliminada = _marcaStore.ObtenerPorId(id);

                if (marcaEliminada == null)
                {
                    // Si no se encuentra la marca, devuelve una respuesta NotFound
                    return NotFound();
                }

                _marcaStore.Eliminar(id);

                // Devuelve una respuesta Ok con la marca eliminada
                return Ok(marcaEliminada);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

    }
}
