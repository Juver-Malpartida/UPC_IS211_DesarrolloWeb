using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public BaseResponse<EntityUser> Insert(EntityUser user)
        {
            BaseResponse<EntityUser> response = new BaseResponse<EntityUser>();
            try
            {
                using var db = GetSqlConnection();

                var parameters = new DynamicParameters();
                parameters.Add(name: "@IDUSUARIO", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add(name: "@LOGINUSUARIO", value: user.loginusuario, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add(name: "@PASSWORDUSUARIO", value: user.passwordusuario, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add(name: "@IDPERFIL", value: user.idperfil, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameters.Add(name: "@NOMBRES", value: user.nombres, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add(name: "@APELLIDOPATERNO", value: user.apellidopaterno, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add(name: "@APELLIDOMATERNO", value: user.apellidomaterno, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add(name: "@DOCUMENTOIDENTIDAD", value: user.documentoidentidad, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add(name: "@USUARIOCREA", value: user.UsuarioCrea, dbType: DbType.Int32, direction: ParameterDirection.Input);

                db.Execute(sql: "usp_InsertaUsuario", param: parameters, commandType: CommandType.StoredProcedure);

                user.idusuario = parameters.Get<int>("@IDUSUARIO");
                if (user.idusuario == 0)
                {
                    response.IsSuccess = false; response.ErrorCode = "User was not created"; response.ErrorMessage = string.Empty;
                    return response;
                }

                response.IsSuccess = true;
                response.ErrorCode = string.Empty;
                response.ErrorMessage = string.Empty;
                response.Data = user;
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false; response.ErrorCode = ex.Message; response.ErrorMessage = ex.StackTrace;
                return response;
            }
        }

        public BaseResponse<EntityLoginResponse> Login(EntityLoginRequest login)
        {
            BaseResponse<EntityLoginResponse> response = new BaseResponse<EntityLoginResponse>();
            try
            {
                using var db = GetSqlConnection();
                var parameters = new DynamicParameters();
                parameters.Add(name: "@LOGINUSUARIO", value: login.loginusuario, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add(name: "@PASSWORDUSUARIO", value: login.passwordusuario, dbType: DbType.String, direction: ParameterDirection.Input);

                EntityLoginResponse loginResponse = db.Query<EntityLoginResponse>(sql: "usp_user_login", param: parameters, commandType: CommandType.StoredProcedure).FirstOrDefault() ;
                if (loginResponse == null)
                {
                    response.IsSuccess = false; response.ErrorCode = "Error during login"; response.ErrorMessage = "Store procedure return null";
                    return response;
                }

                response.IsSuccess = true;
                response.ErrorCode = string.Empty;
                response.ErrorMessage = string.Empty;
                response.Data = loginResponse;
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false; response.ErrorCode = ex.Message; response.ErrorMessage = ex.StackTrace;
                return response;
            }
        }
    }
}
