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
    [Route("api/area")]
    [ApiController]
    public class AreaController : Controller
    {
        private readonly IAreaRepository areaRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="areaRepository"></param>
        public AreaController(IAreaRepository areaRepository)
        {
            this.areaRepository = areaRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerOperation("GetAreas")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetAreas")]
        public ActionResult GetAreas()
        {
            var ret = areaRepository.GetAreas();

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("admin/insertarea")]
        public ActionResult Insert(EntityArea area)
        {
            var ret = areaRepository.Insert(area, 'N');

            if (ret == null)
                return StatusCode(501);

            return Json(ret);
        }
    }
}
