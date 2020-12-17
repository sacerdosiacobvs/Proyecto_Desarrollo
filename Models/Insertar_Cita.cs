using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Insertar_Cita
    {
        [Required(ErrorMessage = "Ingresar el numero de cedula")]
        public string cedula { get; set; }
        [Required(ErrorMessage = "Ingresar el nombre del paciente")]
        public string paciente { get; set; }
        [Required(ErrorMessage = "Ingresar el motivo")]
        public string motivo { get; set; }

        public void Ingresar_Cita()
        {
            int ID = 0;
            DataSet ds = new DataSet();
            WebReference.WebService_Proyecto ws = new WebReference.WebService_Proyecto();
            ds = ws.Obtener_Todas_Citas();

            int ultimo = ds.Tables[0].Rows.Count;
            if (ultimo == 0)
            {
                ID = 1;
            }
            else
            {
                ID = Convert.ToInt32(ds.Tables[0].Rows[ultimo - 1][0]) + 1;
            }

            string doctor = "Sin asignar";
            ws.Insertar_Cita(ID, Convert.ToInt32(cedula), paciente, motivo, doctor);
        }

        
    }
}