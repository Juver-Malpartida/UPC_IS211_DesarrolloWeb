using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class EmpleadoRepository : BaseRepository, IEmpleadoRepository
    {
        public BaseResponse<List<EntityEmpleado>> GetEmpleados()
        {
            var response = new BaseResponse<List<EntityEmpleado>>();

            try
            {
                using var db = GetSqlConnection();
                List<EntityEmpleado> returnEntity = db.Query<EntityEmpleado>("SNP_Consulta_T_Empleado", commandType: CommandType.StoredProcedure).DefaultIfEmpty().ToList();
                response.IsSuccess = true;
                response.ErrorCode = string.Empty;
                response.ErrorMessage = string.Empty;
                response.Data = returnEntity;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorCode = "0002";
                response.ErrorMessage = ex.Message;
                response.Data = null;
            }

            return response;
        }
    }
}
