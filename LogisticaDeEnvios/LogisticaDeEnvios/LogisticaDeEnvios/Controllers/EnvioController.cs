using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using LogisticaDeEnvios.Models;
using LIbreria.DTOs.DTOs.DTOsEnvio;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaAplicacion.ICasosUso.ICUAgencia;
using Libreria.LogicaAplicacion.CasosUso.CUEnvio;
using Libreria.LogicaAplicacion.CasosUso.CUUsuario;
using LIbreria.DTOs.DTOs.DTOsUsuario;
using LIbreria.DTOs.DTOs.DTOsSeguimiento;
using Microsoft.IdentityModel.Tokens;
using Libreria.LogicaAplicacion.ICasosUso.ICUSeguimiento;
using Humanizer;
using Libreria.LogicaNegocio.CustomExceptions.ExceptionsUsuario;
using LogisticaDeEnvios.Filtros;

namespace LogisticaDeEnvios.Controllers
{
    public class EnvioController : Controller
    {
        private ICUObtenerUsuario _cUObtenerUsuario;
        private ICUListarUsuarios _cUListarUsuarios;
        private ICUAltaEnvio _cUOAltaEnvio;
        private ICUObtenerEnvio _CUObtenerEnvio;
        private ICUListarEnvio _CUListarEnvios;
        private ICUListarAgencias _CUListarAgencias;
        private ICUAltaSeguimiento _CUAltaSeguimiento;
        private ICUFinalizarEnvio _CUFinalizarEnvio;

        public EnvioController(ICUObtenerUsuario cUObtenerUsuario,
            ICUListarUsuarios cUListarUsuarios,
            ICUAltaEnvio cUAltaEnvio,
            ICUObtenerEnvio CUObtenerEnvio,
            ICUListarEnvio cUListarEnvios,
            ICUListarAgencias cUListarAgencias,
            ICUAltaSeguimiento cUAltaSeguimiento,
            ICUFinalizarEnvio CUFinalizarEnvio
            )
        {
            _cUObtenerUsuario = cUObtenerUsuario;
            _cUListarUsuarios = cUListarUsuarios;
            _cUOAltaEnvio = cUAltaEnvio;
            _CUObtenerEnvio = CUObtenerEnvio;
            _CUListarEnvios = cUListarEnvios;
            _CUListarAgencias = cUListarAgencias;
            _CUAltaSeguimiento = cUAltaSeguimiento;
            _CUFinalizarEnvio = CUFinalizarEnvio;
        }
        public IActionResult Index()
        {

            return View(_CUListarEnvios.ListarEnvios());
        }

        public IActionResult TipoEnvio()
        {

            return View();
        }


        [HttpPost]
        public IActionResult TipoEnvio(string tipo)
        {

            if (tipo == "comun")
            {
                return RedirectToAction("CreateEnvioComun", "Envio");
            }
            else if (tipo == "urgente")
            {

                return RedirectToAction("CreateEnvioUrgente", "Envio");
            }
            else
            {
                TempData["Mensaje"] = "Seleccione un tipo de envio";
                return View();
            }

        }
        public IActionResult CreateEnvioComun()

        {

            AltaEnvioComunViewModel vm = new AltaEnvioComunViewModel();


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
        public IActionResult CreateEnvioComun(AltaEnvioComunViewModel vm)
        {

            try
            {
                if (vm.Dto.AgenciaId != -1)
                {
                    vm.Dto.FuncionarioId = HttpContext.Session.GetInt32("LogueadoId");

                    _cUOAltaEnvio.AltaEnvioComun(vm.Dto);

                    return RedirectToAction("Index", "Envio");
                }
                else 
                {
                    TempData["Mensaje"] = "Seleccione una agencia";
                    return View(vm);
                }

            }
            catch (ExeptionEmailNoValido e)
            {


                foreach (var agencia in _CUListarAgencias.ListarAgencias())
                {

                    SelectListItem sItem = new SelectListItem();
                    sItem.Text = agencia.Nombre;
                    sItem.Value = agencia.Id.ToString();
                    vm.Agencia.Add(sItem);


                }
     
          

                TempData["Mensaje"] = e.Message;

                return View(vm);
            }
        }

        public IActionResult CreateEnvioUrgente()

        {

            AltaEnvioUrgenteViewModel vm = new AltaEnvioUrgenteViewModel();

     

            
            return View(vm);
        }
        [HttpPost]
        public IActionResult CreateEnvioUrgente(AltaEnvioUrgenteViewModel vm)
        {

            try
            {
                if (vm.Dto.AgenciaId != -1) { 

                    vm.Dto.FuncionarioId = HttpContext.Session.GetInt32("LogueadoId");

                    _cUOAltaEnvio.AltaEnvioUrgente(vm.Dto);

                    return RedirectToAction("Index", "Envio");
                }
                else
                {
                    TempData["Mensaje"] = "Seleccione una agencia";
                    return View(vm);
                }

            }
            catch (ExeptionEmailNoValido e)
            {



                foreach (var cliente in _cUListarUsuarios.ListarUsuario())
                {
                    if (cliente.Rol == "Cliente")
                    {
                        SelectListItem sItem = new SelectListItem();
                        sItem.Text = cliente.Nombre;
                        sItem.Value = cliente.Id.ToString();
                        vm.Cliente.Add(sItem);

                    }
                }


                TempData["Mensaje"] = e.Message;

                return View(vm);
            }
        }

        public IActionResult AddSeguimiento(int id)
        {
            AltaSeguimientoViewModel vm = new AltaSeguimientoViewModel();

          
            vm.Envio =_CUObtenerEnvio.ObtenerEnvio(id);
           
            return View(vm);
        }



        [HttpPost]
        public IActionResult AddSeguimiento(AltaSeguimientoViewModel vm)
        {

            try
            { 
                
                int? lid = HttpContext.Session.GetInt32("LogueadoId");
                vm.Dto.Envio = vm.Envio.Id;
                vm.Dto.Funcionario = (int)lid;
              
                _CUAltaSeguimiento.AltaSeguimiento(vm.Dto);
                TempData["Mensaje"] = "Seguimiento agregado correctamente";


            }
            catch (Exception e)
            {

                ViewBag.msg = e.Message;
            }


            return View();

        }

        public IActionResult FinEnvio(int id)
        {
            return View(_CUObtenerEnvio.ObtenerEnvio(id));
        }

        [HttpPost]
        public IActionResult FinEnvio(DTOEnvio dto)
        {
            try
            {

                int? lid = HttpContext.Session.GetInt32("LogueadoId");
                _CUFinalizarEnvio.FinalizarEnvio(dto);
                TempData["Mensaje"] = "Envio finalizado";
                return RedirectToAction("Index" ,"Envio");
                
            }
            catch (ExceptionFechaNoValida e)
            {
                TempData["Mensaje"] = e.Message;

            }
            return View();
        }
    }


    }




