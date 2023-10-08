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
        [Route("creartarea/{id}/{titulo}/{descripcion}/{estado}")]
        public IActionResult crearTarea(int id,string titulo,string descripcion,string estado)
        {
            manejoTarea.crearTarea(id,titulo,descripcion,estado);
            return Ok();
        }
        [HttpGet]
        [Route("gettarea/{id}")]
        public IActionResult GetTarea(int id)
        {
            Tarea tarea = manejoTarea.getTareaId(id);
            return Ok(tarea);
        }

    }
}