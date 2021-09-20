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
        public BaseResponse<EntitySolicitudCese> GetSolicitud(int id)
        {
            var response = new BaseResponse<EntitySolicitudCese>() { IsSuccess = true, ErrorCode = "", ErrorMessage = "" };
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

        public BaseResponse<List<EntitySolicitudCese>> GetSolicitudes()
        {
            var response = new BaseResponse<List<EntitySolicitudCese>>();

            try
            {
                using var db = GetSqlConnection();
                List<EntitySolicitudCese> returnEntity = db.Query<EntitySolicitudCese>("SNP_Consulta_T_SolicitudSede", commandType: CommandType.StoredProcedure).DefaultIfEmpty().ToList();
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
            throw new NotImplementedException();
        }
    }
}
