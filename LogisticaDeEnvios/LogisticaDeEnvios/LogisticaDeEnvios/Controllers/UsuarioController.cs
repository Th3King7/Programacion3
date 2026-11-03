using Humanizer;
using Libreria.LogicaAplicacion.ICasosUso.ICUAgencia;
using Libreria.LogicaAplicacion.ICasosUso.ICUAltaUsuario;
using Libreria.LogicaAplicacion.ICasosUso.ICULogin;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.ExceptionsUsuario;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Entidades.Enumerados.UsuarioEnums;
using Libreria.LogicaNegocio.InterfaceRepositorio;
using LIbreria.DTOs.DTOs.DTOsUsuario;
using LogisticaDeEnvios.Filtros;
using LogisticaDeEnvios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;

namespace LogisticaDeEnvios.Controllers
{
    public class UsuarioController : Controller
    {

        private ICULogin _CULogin;
        private ICUAltaUsuario _CUAltaUsuario;
        private ICUListarUsuarios _CUListarUsuarios;
        private ICUObtenerUsuario _CUObtenerUsuario;
        private ICUEditarUsuario _CUEditarUsuario;
        private ICUBorrarUsuario _CUBorrarUsuario;
        private ICUListarAgencias _CUListarAgencias;
        private IRepositorioAuditoria _repoAuditoria;



        public UsuarioController(ICUAltaUsuario CUAltaUsuario,
            ICULogin culogin,
            ICUListarUsuarios CUListarUsuarios,
            ICUObtenerUsuario cUObtenerUsuario,
            ICUEditarUsuario cUEditarUsuario,
            ICUBorrarUsuario CUBorrarUsuario,
            ICUListarAgencias CUListarAgencias,
            IRepositorioAuditoria RepoAuditoria
            )
        {
            _CUAltaUsuario = CUAltaUsuario;
            _CULogin = culogin;
            _CUListarUsuarios = CUListarUsuarios;
            _CUObtenerUsuario = cUObtenerUsuario;
            _CUEditarUsuario = cUEditarUsuario;
            _CUBorrarUsuario = CUBorrarUsuario;
            _CUListarAgencias = CUListarAgencias;
            _repoAuditoria = RepoAuditoria;
        }


  
        public IActionResult Index()
        {
            return View(_CUListarUsuarios.ListarUsuario());
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(DTOUsuario dto)

        {
            try
            {
                if (!dto.Email.IsNullOrEmpty() && !dto.Password.IsNullOrEmpty())
                {
                    DTOUsuario b = _CULogin.VerificarDatosParaLogin(dto);
                    HttpContext.Session.SetInt32("LogueadoId", (int)b.Id);
                    HttpContext.Session.SetString("LogueadoRol", b.Rol);
                    return RedirectToAction("Index", "Home");
                }else
                {
                    TempData["Mensaje"] = "Campos vacios";
                }
                    return View();

            }           
            catch (ExceptionPasswordNoValido e)
            {
                TempData["Mensaje"] = e.Message;

                return View();
            }
            catch (ExeptionEmailNoValido e)
            {
                TempData["Mensaje"] = e.Message;

                return View();
            }
        }

        public IActionResult Logout() {

            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [AdministradorAuthorize]

        public IActionResult Create()
        {
            AltaUsuarioViewModel vm = new AltaUsuarioViewModel();

            foreach (var agencia in _CUListarAgencias.ListarAgencias())
            {

                SelectListItem sItem = new SelectListItem();
                sItem.Text = agencia.Nombre;
                sItem.Value = agencia.Id.ToString();
                vm.Agencia.Add(sItem);


            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(AltaUsuarioViewModel vm)
        {
            if (!ModelState.IsValid)
            {

                TempData["Mensaje"] = "Corrige los errores en el formulario.";
                return View(vm);
            }

            try
            {
                if (vm.DtoAlta.Rol == -1) 
                {
                    TempData["Mensaje"] = "Rol invalido";
                    return View(vm);
                }else { 
                    int? lid = HttpContext.Session.GetInt32("LogueadoId");
                    vm.DtoAlta.LogueadoId = lid;

                    _CUAltaUsuario.AltaUsuario(vm.DtoAlta);
                    TempData["Mensaje"] = "Alta de usuario correctamente";
                    return RedirectToAction("Index");
                 }
            }
            catch (ExceptionEmailYaExiste e)
            {
                ViewBag.msg = e.Message;
                TempData["Mensaje"] = e.Message;

            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;               
            }
            return View(vm);
        }
        public IActionResult Edit(int id)
        {
            EditUsuarioViewModel vm = new EditUsuarioViewModel();

            foreach (var agencia in _CUListarAgencias.ListarAgencias())
            {
                SelectListItem sItem = new SelectListItem();
                sItem.Text = agencia.Nombre;
                sItem.Value = agencia.Id.ToString();
                vm.Agencia.Add(sItem);
            }

            vm.DtoEdit = _CUObtenerUsuario.ObtenerUsuario(id);

            return View(vm); 
        }

        [HttpPost]
        public IActionResult Edit(EditUsuarioViewModel vm)
        {

            try
            {

                if (vm.DtoEdit.Rol != "-1")
                {
                    int? lid = HttpContext.Session.GetInt32("LogueadoId");

                    _CUEditarUsuario.EditarUsuario(vm.DtoEdit);
                    TempData["Mensaje"] = "Usuario editado correctamente";
                }
                else
                {

                    TempData["Mensaje"] = "Datos Incorrectos";
                    return View(vm);

                }

            }
            catch (ExceptionEmailYaExiste e)
            {
                TempData["Mensaje"] = e.Message;

            }
            catch (Exception e)
            {
                TempData["Mensaje"] = e.Message;

            }
            foreach (var agencia in _CUListarAgencias.ListarAgencias())
            {
                SelectListItem sItem = new SelectListItem();
                sItem.Text = agencia.Nombre;
                sItem.Value = agencia.Id.ToString();
                vm.Agencia.Add(sItem);
            }
            return View(vm);

        }
        public IActionResult Delete(int id)
        {
            DTOUsuario dto = _CUObtenerUsuario.ObtenerUsuario(id);
            return View(dto); 
        }

        [HttpPost]
        public IActionResult Delete(DTOUsuario dto)
        {
            _CUBorrarUsuario.EliminarUsuario(dto);
            return RedirectToAction("Index" ,"Usuario");
        }


    }
}
