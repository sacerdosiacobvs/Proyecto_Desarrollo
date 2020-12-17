using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WS_Proyecto
{
    /// <summary>
    /// Descripción breve de WebService_Proyecto
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService_Proyecto : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public DataSet Obtener_Usuario(string id, string password)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Clinica;User ID=Progra5;Password=Progra5");
            SqlCommand sql = new SqlCommand("Select * from T_USUARIOS where ID="+id+" AND PASSWORD='"+password+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet Obtener_Todos_Usuarios()
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Clinica;User ID=Progra5;Password=Progra5");
            SqlCommand sql = new SqlCommand("Select * from T_USUARIOS", con);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet Obtener_Todos_Doctores()
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Clinica;User ID=Progra5;Password=Progra5");
            SqlCommand sql = new SqlCommand("Select * from T_USUARIOS where TIPO_USUARIO='Dentista'", con);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public void Registrar_Usuario(int cedula, string nombre, string tipo, string password)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Clinica;User ID=Progra5;Password=Progra5");
            string SQL = "insert into T_USUARIOS (ID, NOMBRE, TIPO_USUARIO, PASSWORD) values(" + cedula + ", '" + nombre + "', '" + tipo + "', '" + password + "')";
            SqlCommand sql = new SqlCommand(SQL, con);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            da.Fill(ds);
        }

        [WebMethod]
        public void Modificar_Usuario(int cedula, string nombre, string tipo, string password)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Clinica;User ID=Progra5;Password=Progra5");
            string SQL = "update T_USUARIOS set NOMBRE='" + nombre + "', TIPO_USUARIO='" + tipo + "', PASSWORD='" + password + "' where ID=" + cedula;
            SqlCommand sql = new SqlCommand(SQL, con);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            da.Fill(ds);
        }

        [WebMethod]
        public void Insertar_Cita(int id, int cedula, string paciente, string motivo, string doctor)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Clinica;User ID=Progra5;Password=Progra5");
            string SQL = "insert into T_CITAS (ID, CEDULA, PACIENTE, MOTIVO, DOCTOR) values(" + id + ", " + cedula + ", '" + paciente + "', '" + motivo + "', '" + doctor + "')";
            SqlCommand sql = new SqlCommand(SQL, con);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            da.Fill(ds);
        }

        [WebMethod]
        public void Set_Doctor_Cita(int id, string doctor)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Clinica;User ID=Progra5;Password=Progra5");
            string SQL = "update T_CITAS set DOCTOR='"+doctor+"' where ID="+id;
            SqlCommand sql = new SqlCommand(SQL, con);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            da.Fill(ds);
        }

        [WebMethod]
        public DataSet Obtener_Todas_Citas()
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Clinica;User ID=Progra5;Password=Progra5");
            SqlCommand sql = new SqlCommand("Select * from T_CITAS", con);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet Obtener_Citas_Paciente(string cedula)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Clinica;User ID=Progra5;Password=Progra5");
            SqlCommand sql = new SqlCommand("Select * from T_CITAS where CEDULA=@cedula", con);
            sql.Parameters.Add("@cedula", SqlDbType.NVarChar);
            sql.Parameters[0].Value = cedula;
            SqlDataAdapter da = new SqlDataAdapter(sql);
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet Obtener_Citas_Doctor(string nombre)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Clinica;User ID=Progra5;Password=Progra5");
            SqlCommand sql = new SqlCommand("Select * from T_CITAS where DOCTOR=@nombre", con);
            sql.Parameters.Add("@nombre", SqlDbType.NVarChar);
            sql.Parameters[0].Value = nombre;
            SqlDataAdapter da = new SqlDataAdapter(sql);
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet Eliminar_Usuario(int id)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Clinica;User ID=Progra5;Password=Progra5");
            SqlCommand sql = new SqlCommand("Delete from T_USUARIOS where ID=@id", con);
            sql.Parameters.Add("@id", SqlDbType.NVarChar);
            sql.Parameters[0].Value = id;
            SqlDataAdapter da = new SqlDataAdapter(sql);
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet Eliminar_Cita(int id)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Clinica;User ID=Progra5;Password=Progra5");
            SqlCommand sql = new SqlCommand("Delete from T_CITAS where ID=@id", con);
            sql.Parameters.Add("@id", SqlDbType.NVarChar);
            sql.Parameters[0].Value = id;
            SqlDataAdapter da = new SqlDataAdapter(sql);
            da.Fill(ds);
            return ds;
        }
    }
}
