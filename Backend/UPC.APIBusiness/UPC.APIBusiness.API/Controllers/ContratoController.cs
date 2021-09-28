using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    [Route("api/Contrato")]
    [ApiController]
    public class ContratoController : Controller
    {
        private readonly IContratoRepository contratoRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contratoRepository"></param>
        public ContratoController(IContratoRepository contratoRepository)
        {
            this.contratoRepository = contratoRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetContratos")]
        public ActionResult GetContratos()
        {
            var ret = contratoRepository.GetContratos();

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contrato"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("admin/InsertContrato")]
        public ActionResult Insert(EntityContrato contrato)
        {
            var ret = contratoRepository.Insert(contrato, 'N');

            if (ret == null)
                return StatusCode(501);

            return Json(ret);
        }
    }
}
