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
                List<Empleado> empleados = _empleadoStore.ObtenerTodo();
                return Ok(empleados);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult ObtenerEmpleado(int id)
        {
            try
            {
                Empleado empleado = _empleadoStore.ObtenerPorId(id);

                if (empleado == null)
                    return NotFound();

                return Ok(empleado);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarEmpleado([FromBody] Empleado nuevoEmpleado)
        {
            try
            {
                _empleadoStore.Agregar(nuevoEmpleado);
                List<Empleado> empleados = _empleadoStore.ObtenerTodo();
                return Ok(empleados);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarEmpleado(int id, [FromBody] Empleado empleadoActualizado)
        {
            try
            {
                _empleadoStore.Actualizar(id, empleadoActualizado);
                Empleado empleadoActualizadoResult = _empleadoStore.ObtenerPorId(id);
                return Ok(empleadoActualizadoResult);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarEmpleado(int id)
        {
            try
            {
                Empleado empleadoEliminado = _empleadoStore.ObtenerPorId(id);

                if (empleadoEliminado == null)
                {
                    return NotFound();
                }

                _empleadoStore.Eliminar(id);
                return Ok(empleadoEliminado);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
