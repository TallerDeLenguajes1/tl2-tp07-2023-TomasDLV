using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace tl2_tp07_2023_TomasDLV.Models
{
    public class AccesoTarea
    {

        public List<Tarea> Obtener()
        {
            string contenido = File.ReadAllText("Models/tareas.json");
            List<Tarea> tareas;
            tareas = JsonSerializer.Deserialize<List<Tarea>>(contenido);

            return tareas;
        }

        public bool Guardar(List<Tarea> tareas)
        {
            string contenido = JsonSerializer.Serialize(tareas);
            File.WriteAllText("Models/tareas.json", contenido);
            return true;
        }


    }
}