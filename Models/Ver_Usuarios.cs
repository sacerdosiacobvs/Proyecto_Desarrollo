using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Ver_Usuarios
    {
        public DataSet Obtener_Usuarios_Tabla()
        {
            DataSet ds = new DataSet();
            WebReference.WebService_Proyecto ws = new WebReference.WebService_Proyecto();
            DataTable datatable = new DataTable();
            ds = ws.Obtener_Todos_Usuarios();
            return ds;
        }
    }
}