using Domain.Endpoint.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Application.Endpoint;

namespace WebApi.Controllers
{
    public class EmpleadoController : ApiController
    {
        private AlmacenEntidades<Empleado> _empleadoStore;

        public EmpleadoController()
        {
            _empleadoStore = new AlmacenEntidades<Empleado>(e => e.Id);
        }

        [HttpGet]
        public IHttpActionResult ObtenerEmpleados()
        {
            try
            {
                // Obtiene la lista de todos los empleados
                List<Empleado> empleados = _empleadoStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de empleados
                return Ok(empleados);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerEmpleado(int id)
        {
            try
            {
                // Intenta obtener un empleado por su ID
                Empleado empleado = _empleadoStore.ObtenerPorId(id);

                if (empleado == null)
                    // Si no se encuentra el empleado, devuelve una respuesta NotFound
                    return NotFound();

                // Si se encuentra el empleado, devuelve una respuesta Ok con el empleado
                return Ok(empleado);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarEmpleado([FromBody] Empleado nuevoEmpleado)
        {
            try
            {
                // Agrega un nuevo empleado
                _empleadoStore.Agregar(nuevoEmpleado);

                // Obtiene la lista actualizada de empleados
                List<Empleado> empleados = _empleadoStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de empleados
                return Ok(empleados);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarEmpleado(int id, [FromBody] Empleado empleadoActualizado)
        {
            try
            {
                // Intenta actualizar el empleado por su ID
                _empleadoStore.Actualizar(id, empleadoActualizado);

                // Obtiene la lista actualizada de empleados
                List<Empleado> empleados = _empleadoStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de empleados
                return Ok(empleados);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarEmpleado(int id)
        {
            try
            {
                // Intenta eliminar el empleado por su ID
                _empleadoStore.Eliminar(id);

                // Obtiene la lista actualizada de empleados
                List<Empleado> empleados = _empleadoStore.ObtenerTodo();

                // Devuelve una respuesta Ok con la lista de empleados
                return Ok(empleados);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devuelve una respuesta InternalServerError con el error
                return InternalServerError(ex);
            }
        }
    }
}
