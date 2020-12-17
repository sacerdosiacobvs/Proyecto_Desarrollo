using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using Proyecto.Controllers;

namespace Proyecto.Models
{
    public class Login
    {  
        [Required(ErrorMessage = "Ingrese su numero de cedula")]
        public string cedula { get; set; }
        [Required(ErrorMessage = "Ingrese su contraseña")]
        public string password { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }

        public Boolean Ingresar()
        {
            try
            {
                DataSet ds = new DataSet();
                WebReference.WebService_Proyecto ws = new WebReference.WebService_Proyecto();
                ds = ws.Obtener_Usuario(cedula,password);
                nombre = ds.Tables[0].Rows[0][1].ToString();
                tipo = ds.Tables[0].Rows[0][2].ToString();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        
    }
}