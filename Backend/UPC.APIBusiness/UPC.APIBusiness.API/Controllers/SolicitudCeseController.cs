using DBContext;
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
    [Route("api/Solicitud")]
    public class SolicitudCeseController : Controller
    {
        private readonly ISolicitudCeseRepository solicitudCeseRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="solicitudCeseRepository"></param>
        public SolicitudCeseController(ISolicitudCeseRepository solicitudCeseRepository)
        {
            this.solicitudCeseRepository = solicitudCeseRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerOperation("GetListSolicitud")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetListSolicitud")]
        public IActionResult Get()
        {
            var solicitudes = solicitudCeseRepository.GetSolicitudes();
            if (solicitudes == null) return StatusCode(401);
            return Json(solicitudes);
        }
    }
}
