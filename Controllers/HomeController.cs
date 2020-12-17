using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult V_Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult V_Login(Login login)
        {
            if (ModelState.IsValid) {
                if (login.Ingresar())
                {
                    Credenciales.u_nombre = login.nombre;
                    Credenciales.u_cedula = login.cedula;
                    Credenciales.u_tipo = login.tipo;
                    return View("Info");
                }
                return View();
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult Info()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Insertar_Cita()
        {
            Insertar_Cita insertar_Cita = new Insertar_Cita();
            return View(insertar_Cita);
        }

        [HttpPost]
        public ActionResult Insertar_Cita(Insertar_Cita insertar_cita)
        {
            if (ModelState.IsValid)
            {
                insertar_cita.Ingresar_Cita();
                ModelState.Clear();
                return View();
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult Registrar_Usuario()
        {
            Registrar_Usuario reg_usuario = new Registrar_Usuario();
            return View(reg_usuario);
        }

        [HttpPost]
        public ActionResult Registrar_Usuario(Registrar_Usuario registrar_usuario)
        {

            if (ModelState.IsValid)
            {
                registrar_usuario.Registrar();
                ModelState.Clear();
                return View();
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult Set_Cita_Doctor(string id)
        {
            Ver_Citas ver_citas = new Ver_Citas();
            ver_citas.id = Convert.ToInt32(id);
            ViewBag.Citas = ver_citas.Obtener_Todos_Dentistas();
            return View(ver_citas);
        }

        [HttpPost]
        public ActionResult Set_Cita_Doctor(Ver_Citas ver_citas)
        {
            if (ModelState.IsValid)
            {
                ver_citas.Set_Doctor();
                ModelState.Clear();
                ver_citas.doctor="";
                return View(ver_citas);
            }
            else
                return View(ver_citas);
        }

        [HttpGet]
        public ActionResult Ver_Todas_Citas()
        {
            Ver_Citas ver_citas = new Ver_Citas();
            ViewBag.Citas = ver_citas.Obtener_Citas_Tabla();
            return View(ver_citas);
        }

        [HttpGet]
        public ActionResult Ver_Citas_Cliente()
        {
            Ver_Citas ver_citas = new Ver_Citas();
            ViewBag.Citas = ver_citas.Obtener_Citas_Clientes(Credenciales.u_cedula);
            return View(ver_citas);
        }

        [HttpGet]
        public ActionResult Ver_Citas_Dentista()
        {
            Ver_Citas ver_citas = new Ver_Citas();
            ViewBag.Citas = ver_citas.Obtener_Citas_Dentista(Credenciales.u_nombre);
            return View(ver_citas);
        }

        [HttpGet]
        public ActionResult Ver_Todos_Usuarios()
        {
            Ver_Usuarios ver_usuarios = new Ver_Usuarios();
            ViewBag.Usuarios = ver_usuarios.Obtener_Usuarios_Tabla();
            return View(ver_usuarios);
        }

        [HttpGet]
        public ActionResult Modificar_Usuarios(int id)
        {
            Registrar_Usuario reg_usuario = new Registrar_Usuario();
            reg_usuario.cedula = id.ToString();
            return View(reg_usuario);
        }

        [HttpPost]
        public ActionResult Modificar_Usuarios(Registrar_Usuario reg_usuario)
        {
            if (ModelState.IsValid)
            {
                reg_usuario.Modificar_Usuario();
                ModelState.Clear();
                return View(reg_usuario);
            }
            else
                return View(reg_usuario);
        }

        [HttpGet]
        public ActionResult Modificar_Usuario_Actual()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Modificar_Usuario_Actual(Registrar_Usuario reg_usuario)
        {
            if (ModelState.IsValid)
            {
                reg_usuario.Modificar_Usuario();
                Credenciales.u_nombre = reg_usuario.nombre;
                Credenciales.u_cedula = reg_usuario.cedula;
                Credenciales.u_tipo = reg_usuario.tipo_nuevo_usuario;
                ModelState.Clear();
                return View(reg_usuario);
            }
            else
                return View(reg_usuario);
        }

        [HttpGet]
        public ActionResult Cancelar_Cita(int id)
        {
            Ver_Citas in_cita = new Ver_Citas();
            in_cita.id_cita = id;
            in_cita.Cancelar_Cita();
            return View(in_cita);
        }
    }
}