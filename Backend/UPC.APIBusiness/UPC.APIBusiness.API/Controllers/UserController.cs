using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UPC.E31A.APIBusiness.API.Security;

namespace UPC.APIBusiness.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(EntityLoginRequest loginRequest)
        {
            BaseResponse<EntityLoginResponse> response = userRepository.Login(loginRequest);
            if (response.Data == null) return Json(response);

            string codigoUsuario = response.Data.idusuario.ToString();
            string numeroDocument = response.Data.documentoidentidad;
            string jsonResponse = await new Authentication().GenerateToken(codigoUsuario, numeroDocument);
            AccessToken token = JsonConvert.DeserializeObject<AccessToken>(jsonResponse);
            response.Data.token = token.access_token;
            return Json(response);
        }
    }
}
