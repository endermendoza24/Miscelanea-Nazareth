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
                // Obtiene la lista de todas las categorías
                List<Categoria> categorias = _categoriaStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de categorías
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerCategoria(int id)
        {
            try
            {
                // Intenta obtener una categoría por su ID
                Categoria categoria = _categoriaStore.ObtenerPorId(id);

                if (categoria == null)
                    // Si no se encuentra la categoría, devuelve una respuesta NotFound
                    return NotFound();

                // Si se encuentra la categoría, devuelve una respuesta Ok con la categoría
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarCategoria([FromBody] Categoria nuevaCategoria)
        {
            try
            {
                // Agrega una nueva categoría
                _categoriaStore.Agregar(nuevaCategoria);

                // Obtiene la lista actualizada de categorías
                List<Categoria> categorias = _categoriaStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de categorías
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarCategoria(int id, [FromBody] Categoria categoriaActualizada)
        {
            try
            {
                // Intenta actualizar la categoría por su ID
                _categoriaStore.Actualizar(id, categoriaActualizada);

                // Obtiene la lista actualizada de categorías
                List<Categoria> categorias = _categoriaStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de categorías
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarCategoria(int id)
        {
            try
            {
                // Intenta eliminar la categoría por su ID
                _categoriaStore.Eliminar(id);

                // Obtiene la lista actualizada de categorías
                List<Categoria> categorías = _categoriaStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de categorías
                return Ok(categorías);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }
    }
}
