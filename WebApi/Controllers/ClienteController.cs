using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Application.Endpoint;

namespace WebApi.Controllers
{
    public class ClienteController : ApiController
    {
        private AlmacenEntidades<Cliente> _clienteStore;

        public ClienteController()
        {
            _clienteStore = new AlmacenEntidades<Cliente>(c => c.Id);
        }

        [HttpGet]
        public IHttpActionResult ObtenerClientes()
        {
            try
            {
                // Obtiene la lista de todos los clientes
                List<Cliente> clientes = _clienteStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de clientes
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerCliente(int id)
        {
            try
            {
                // Intenta obtener un cliente por su ID
                Cliente cliente = _clienteStore.ObtenerPorId(id);

                if (cliente == null)
                    // Si no se encuentra el cliente, devuelve una respuesta NotFound
                    return NotFound();

                // Si se encuentra el cliente, devuelve una respuesta Ok con el cliente
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarCliente([FromBody] Cliente nuevoCliente)
        {
            try
            {
                // Agrega un nuevo cliente
                _clienteStore.Agregar(nuevoCliente);

                // Obtiene la lista actualizada de clientes
                List<Cliente> clientes = _clienteStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de clientes
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarCliente(int id, [FromBody] Cliente clienteActualizado)
        {
            try
            {
                // Intenta actualizar el cliente por su ID
                _clienteStore.Actualizar(id, clienteActualizado);

                // Obtiene la lista actualizada de clientes
                List<Cliente> clientes = _clienteStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de clientes
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarCliente(int id)
        {
            try
            {
                // Intenta eliminar el cliente por su ID
                _clienteStore.Eliminar(id);

                // Obtiene la lista actualizada de clientes
                List<Cliente> clientes = _clienteStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de clientes
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }
    }
}
