using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Models
{
    public class Ver_Citas
    {

        [Required(ErrorMessage = "Ingrese la cédula")]
        public int id { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del doctor")]
        public string doctor { get; set; }

        public DataSet Obtener_Citas_Tabla()
        {
            DataSet ds = new DataSet();
            WebReference.WebService_Proyecto ws = new WebReference.WebService_Proyecto();
            DataTable datatable = new DataTable();
            ds = ws.Obtener_Todas_Citas();
            return ds;
        }

        public DataSet Obtener_Citas_Clientes(string string_id)
        {
            DataSet ds = new DataSet();
            WebReference.WebService_Proyecto ws = new WebReference.WebService_Proyecto();
            DataTable datatable = new DataTable();
            ds = ws.Obtener_Citas_Paciente(string_id);
            return ds;
        }

        public DataSet Obtener_Citas_Dentista(string nombre)
        {
            DataSet ds = new DataSet();
            WebReference.WebService_Proyecto ws = new WebReference.WebService_Proyecto();
            DataTable datatable = new DataTable();
            ds = ws.Obtener_Citas_Doctor(nombre);
            return ds;
        }

        public void Set_Doctor()
        {
            DataSet ds = new DataSet();
            WebReference.WebService_Proyecto ws = new WebReference.WebService_Proyecto();
            DataTable datatable = new DataTable();
            ws.Set_Doctor_Cita(id,doctor);
        }

        public int id_cita { get; set; }

        public void Cancelar_Cita()
        {
            WebReference.WebService_Proyecto ws = new WebReference.WebService_Proyecto();
            ws.Eliminar_Cita(id_cita);
        }


        public DataSet Obtener_Todos_Dentistas()
        {
            DataSet ds = new DataSet();
            WebReference.WebService_Proyecto ws = new WebReference.WebService_Proyecto();
            DataTable datatable = new DataTable();
            ds = ws.Obtener_Todos_Doctores();
            return ds;
        }
    }
}