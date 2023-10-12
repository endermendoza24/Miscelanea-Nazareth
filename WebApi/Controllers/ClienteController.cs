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
                List<Cliente> clientes = _clienteStore.ObtenerTodo();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerCliente(int id)
        {
            try
            {
                Cliente cliente = _clienteStore.ObtenerPorId(id);

                if (cliente == null)
                    return NotFound();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarCliente([FromBody] Cliente nuevoCliente)
        {
            try
            {
                _clienteStore.Agregar(nuevoCliente);
                List<Cliente> clientes = _clienteStore.ObtenerTodo();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarCliente(int id, [FromBody] Cliente clienteActualizado)
        {
            try
            {
                _clienteStore.Actualizar(id, clienteActualizado);
                Cliente clienteActualizadoResult = _clienteStore.ObtenerPorId(id);
                return Ok(clienteActualizadoResult);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarCliente(int id)
        {
            try
            {
                Cliente clienteEliminado = _clienteStore.ObtenerPorId(id);

                if (clienteEliminado == null)
                {
                    return NotFound();
                }

                _clienteStore.Eliminar(id);
                return Ok(clienteEliminado);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
