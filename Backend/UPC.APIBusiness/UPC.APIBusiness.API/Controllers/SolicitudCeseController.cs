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
    [Route("api/Solicitud")]
    [ApiController]
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
        [SwaggerOperation("GetSolicitudes")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetSolicitudes")]
        public IActionResult GetSolicitudes()
        {
            var solicitudes = solicitudCeseRepository.GetSolicitudes();
            if (solicitudes == null) return StatusCode(401);
            return Json(solicitudes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerOperation("GetSolicitud")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetSolicitud")]
        public IActionResult GetSolicitud(int id)
        {
            var solicitudes = solicitudCeseRepository.GetSolicitud(id);
            if (solicitudes == null) return StatusCode(401);
            return Json(solicitudes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solicitudCese"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("InsertSolicitud")]
        public ActionResult Insert(EntitySolicitudCese solicitudCese)
        {
            var ret = solicitudCeseRepository.Insert(solicitudCese);

            if (ret == null)
                return StatusCode(501);

            return Json(ret);
        }
    }
}
