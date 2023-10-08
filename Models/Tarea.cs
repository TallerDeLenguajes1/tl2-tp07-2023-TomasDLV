using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tl2_tp07_2023_TomasDLV.Models
{
    public class Tarea
    {
        private int id;
        private string titulo;
        private string descripcion;
        private string estado;

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Estado { get => estado; set => estado = value; }
        public Tarea(int id,string titulo,string descripcion,string estado){
            this.id =id;
            this.titulo =titulo;
            this.descripcion =descripcion;
            this.estado =estado;
        }
    }
}