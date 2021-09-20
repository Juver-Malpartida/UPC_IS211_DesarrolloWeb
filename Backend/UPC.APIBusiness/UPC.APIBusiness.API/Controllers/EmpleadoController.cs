﻿using DBContext;
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
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoRepository empleadoRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="empleadoRepository"></param>
        public EmpleadoController(IEmpleadoRepository empleadoRepository)
        {
            this.empleadoRepository = empleadoRepository;
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
    }
}