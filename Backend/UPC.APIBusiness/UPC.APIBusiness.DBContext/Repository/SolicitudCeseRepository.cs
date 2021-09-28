using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class SolicitudCeseRepository : BaseRepository, ISolicitudCeseRepository
    {
        public BaseResponse<EntitySolicitudResponse> GetSolicitud(int id)
        {
            var response = new BaseResponse<EntitySolicitudResponse>() { IsSuccess = true, ErrorCode = "", ErrorMessage = "" };
            try
            {
                var solicitudes = GetSolicitudes();
                if (!solicitudes.IsSuccess) throw new Exception("Inner GetSolicitudes method has failed.");
                response.Data = solicitudes.Data.FirstOrDefault(x => x.IdSolCese == id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorCode = "GetSolicitudException";
                response.ErrorMessage = ex.Message;
                response.Data = null;
            }

            return response;
        }

        public BaseResponse<List<EntitySolicitudResponse>> GetSolicitudes()
        {
            var response = new BaseResponse<List<EntitySolicitudResponse>>();

            try
            {
                using var db = GetSqlConnection();
                List<EntitySolicitudResponse> returnEntity = db.Query<EntitySolicitudResponse>("SNP_Consulta_T_SolicitudCese", commandType: CommandType.StoredProcedure).DefaultIfEmpty().ToList();
                response.IsSuccess = true;
                response.ErrorCode = string.Empty;
                response.ErrorMessage = string.Empty;
                response.Data = returnEntity;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorCode = "0001";
                response.ErrorMessage = ex.Message;
                response.Data = null;
            }
            return response;
        }

        public BaseResponse<EntitySolicitudCese> Insert(EntitySolicitudCese solicitudCese)
        {
            BaseResponse<EntitySolicitudCese> response = new BaseResponse<EntitySolicitudCese>();
            try
            {
                using var db = GetSqlConnection();

                var parameters = new DynamicParameters();
                parameters.Add(name: "@pTipoGeneracion", value:"N", dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add(name: "@pIdSolCese", dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
                parameters.Add(name: "@pIdContrato", value: solicitudCese.IdContrato, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameters.Add(name: "@pFechaCese", value: solicitudCese.FechaCese, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                parameters.Add(name: "@pMotivoCese", value: solicitudCese.MotivoCese, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add(name: "@pEstado", value: solicitudCese.Estado, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add(name: "@pUsuarioModificacion", value: solicitudCese.UsuarioModificacion, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add(name: "@pUsuarioCrea", value: solicitudCese.UsuarioCrea, dbType: DbType.String, direction: ParameterDirection.Input);

                db.Execute(sql: "SNP_Insertar_T_SolicitudCese", param: parameters, commandType: CommandType.StoredProcedure);

                solicitudCese.IdSolCese = parameters.Get<int>("@pIdSolCese");
                if (solicitudCese.IdSolCese == 0)
                {
                    response.IsSuccess = false; response.ErrorCode = "Solicitud was not created"; response.ErrorMessage = string.Empty;
                    return response;
                }

                response.IsSuccess = true;
                response.ErrorCode = string.Empty;
                response.ErrorMessage = string.Empty;
                response.Data = solicitudCese;
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
