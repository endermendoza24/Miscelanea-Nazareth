using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Application.Endpoint;

namespace WebApi.Controllers
{
    public class CategoriaController : ApiController
    {
        private AlmacenEntidades<Categoria> _categoriaStore;

        public CategoriaController()
        {
            _categoriaStore = new AlmacenEntidades<Categoria>(c => c.Id);
        }

        [HttpGet]
        public IHttpActionResult ObtenerCategorias()
        {
            try
            {
                List<Categoria> categorias = _categoriaStore.ObtenerTodo();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerCategoria(int id)
        {
            try
            {
                Categoria categoria = _categoriaStore.ObtenerPorId(id);

                if (categoria == null)
                    return NotFound();

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarCategoria([FromBody] Categoria nuevaCategoria)
        {
            try
            {
                _categoriaStore.Agregar(nuevaCategoria);
                List<Categoria> categorias = _categoriaStore.ObtenerTodo();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarCategoria(int id, [FromBody] Categoria categoriaActualizada)
        {
            try
            {
                _categoriaStore.Actualizar(id, categoriaActualizada);
                Categoria categoriaActualizadaResult = _categoriaStore.ObtenerPorId(id);
                return Ok(categoriaActualizadaResult);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarCategoria(int id)
        {
            try
            {
                Categoria categoriaEliminada = _categoriaStore.ObtenerPorId(id);

                if (categoriaEliminada == null)
                {
                    return NotFound();
                }

                _categoriaStore.Eliminar(id);
                return Ok(categoriaEliminada);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
