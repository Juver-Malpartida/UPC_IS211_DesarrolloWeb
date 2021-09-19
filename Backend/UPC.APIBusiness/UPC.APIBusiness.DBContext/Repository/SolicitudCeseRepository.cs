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
    }
}
