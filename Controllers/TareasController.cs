using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tl2_tp07_2023_TomasDLV.Models;

namespace tl2_tp07_2023_TomasDLV.Controllers
{
    [Route("[controller]")]
    public class TareasController : ControllerBase
    {
        private readonly ILogger<TareasController> _logger;
        private ManejoTareas manejoTarea = new();

        public TareasController(ILogger<TareasController> logger)
        {
            _logger = logger;

        }
        [HttpPost]
        [Route("creartarea")]
        public IActionResult crearTarea([FromBody] Tarea tarea)
        {
            if (manejoTarea.getTareaId(tarea.Id) != null)
            {
                return StatusCode(500, "No se pudo crear la tarea, id ya existente");
            }
            else
            {
                manejoTarea.crearTarea(tarea);
                return Ok("Tarea creada correctamente");
            }

        }
        [HttpGet]
        [Route("gettarea/{id}")]
        public IActionResult GetTarea(int id)
        {
            Tarea tarea = manejoTarea.getTareaId(id);
            return Ok(tarea);
        }
        [HttpPut]
        [Route("actualizartarea/{id}")]
        public IActionResult ActualizarTarea(int id, [FromBody] Tarea tarea)
        {
            if (manejoTarea.actualizarTarea(id, tarea))
            {
                return Ok("Se actualizo la tarea "+id);
            }
            else
            {
                return StatusCode(500, "No se pudo actualizar la tarea");
            }
        }
        [HttpDelete]
        [Route("eliminartarea/{id}")]
        public IActionResult EliminarTarea(int id)
        {
            if (manejoTarea.eliminarTarea(id))
            {
                return Ok("Se elimino la tarea "+id);
            }
            else
            {
                return StatusCode(500, "No se pudo eliminar la tarea");
            }
        }
        [HttpGet]
        [Route("listartareas")]
        public IActionResult ListarTareas()
        {
            return Ok(manejoTarea.listarTareas());
        }
        [HttpGet]
        [Route("listartareascompletadas")]
        public IActionResult ListarTareasCompletadas()
        {
            return Ok(manejoTarea.listarTareasCompletadas());
        }
    }
}