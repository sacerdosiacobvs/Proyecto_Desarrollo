using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Registrar_Usuario
    {
        [Required(ErrorMessage = "Ingresar el numero de cedula")]
        public string cedula { get; set; }
        [Required(ErrorMessage = "Ingresar el nombre")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Ingresar la constraseña")]
        public string password { get; set; }
        [Required(ErrorMessage = "Ingresar el tipo de usuario")]
        public string tipo_nuevo_usuario { get; set; }


        public void Registrar()
        {
            WebReference.WebService_Proyecto ws = new WebReference.WebService_Proyecto();

            ws.Registrar_Usuario(Convert.ToInt32(cedula), nombre, tipo_nuevo_usuario,password);
        }

        public void Modificar_Usuario()
        {
            WebReference.WebService_Proyecto ws = new WebReference.WebService_Proyecto();

            ws.Modificar_Usuario(Convert.ToInt32(cedula), nombre, tipo_nuevo_usuario,password);
        }
    }
}