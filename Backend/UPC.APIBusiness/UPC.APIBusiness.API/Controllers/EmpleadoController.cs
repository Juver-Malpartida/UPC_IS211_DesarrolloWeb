using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UPC.APIBusiness.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/Empleado")]
    [ApiController]
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoRepository empleadoRepository;
        private readonly IContratoRepository contratoRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="empleadoRepository"></param>
        /// <param name="contratoRepository"></param>
        public EmpleadoController(IEmpleadoRepository empleadoRepository, IContratoRepository contratoRepository)
        {
            this.empleadoRepository = empleadoRepository;
            this.contratoRepository = contratoRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerOperation("GetListEmpleado")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetListEmpleado")]
        public ActionResult Get()
        {
            var ret = empleadoRepository.GetEmpleados();

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="empleadoRequest"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("InsertEmpleado")]
        public ActionResult Insert(EntityEmpleadoRequest empleadoRequest)
        {
            var retEmpleado = empleadoRepository.InsertEmpleado(empleadoRequest.Empleado);
            if (retEmpleado == null) return StatusCode(501);

            empleadoRequest.Contrato.IdEmpleado = retEmpleado.Data.IdEmpleado;

            var retContrato = contratoRepository.Insert(empleadoRequest.Contrato, 'N');
            if (retContrato == null) return StatusCode(501);

            return Json("Success");
        }
    }
}
