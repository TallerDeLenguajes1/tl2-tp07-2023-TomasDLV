
namespace tl2_tp07_2023_TomasDLV.Models
{
    class ManejoTareas
    {
        public AccesoTarea accesoTarea;
        public List<Tarea> tareas;
        public ManejoTareas(){
            accesoTarea = new AccesoTarea();
            tareas = accesoTarea.Obtener();
        }
        public bool crearTarea(int id,string titulo,string descripcion,string estado){
            var tarea = new Tarea(id,titulo,descripcion,estado);
            tareas.Add(tarea);
            if (accesoTarea.Guardar(tareas))
            {
                return true;
                
            }else
            {
                return false;
            }
            
        }
        public Tarea getTareaId(int id){
            foreach (Tarea t in tareas)
            {
                if (t.Id == id)
                {
                    return t;
                }
            }
            return null;
        }
        public bool actualizarTarea(int id,Tarea tarea){
            foreach (Tarea t in tareas)
            {
                if (t.Id == id)
                {
                        t.Titulo = tarea.Titulo;
                        t.Descripcion = tarea.Descripcion;
                        t.Estado = tarea.Estado;
                        return true;
                }
            }
            return false;
        }
        public bool eliminarTarea(int id){
            Tarea tarea = tareas.FirstOrDefault(t => t.Id == id); 
            if (tarea != null)
            {
                tareas.Remove(tarea);
                return true;
            }
            return false;
        }
        public void listarTareas(){
            foreach (Tarea t in tareas)
            {
                Console.WriteLine("");
                Console.WriteLine("----- Tarea ID : ",t.Id," -----");
                Console.WriteLine("Titulo: ",t.Titulo);
                Console.WriteLine("Descripcion: ", t.Descripcion);
                Console.WriteLine("Estado: ", t.Estado);
                Console.WriteLine("");
            }
        }
        public void listarTareasCompletadas(){
            foreach (Tarea t in tareas)
            {
                if (t.Estado == "Completada")
                {
                    Console.WriteLine("");
                    Console.WriteLine("----- Tarea ID : ",t.Id," -----");
                    Console.WriteLine("Titulo: ",t.Titulo);
                    Console.WriteLine("Descripcion: ", t.Descripcion);
                    Console.WriteLine("");
                }
            }
        }
    }
}