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
        public BaseResponse<List<EntityEmpleadoResponse>> GetEmpleados()
        {
            var response = new BaseResponse<List<EntityEmpleadoResponse>>();

            try
            {
                using var db = GetSqlConnection();
                List<EntityEmpleadoResponse> returnEntity = db.Query<EntityEmpleadoResponse>("SNP_Consulta_T_Empleado", commandType: CommandType.StoredProcedure).DefaultIfEmpty().ToList();
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

        public BaseResponse<EntityEmpleado> InsertEmpleado(EntityEmpleado empleado)
        {
            BaseResponse<EntityEmpleado> response = new BaseResponse<EntityEmpleado>();
            try
            {
                using var db = GetSqlConnection();

                var parameters = new DynamicParameters();
                parameters.Add(name: "@pTipoGeneracion", value: "N", dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add(name: "@pIdEmpleado", dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
                parameters.Add(name: "@pFoto", value: empleado.Foto, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add(name: "@pNombreEmpleado", value: empleado.NombreEmpleado, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add(name: "@pIdCargo", value: empleado.IdCargo, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameters.Add(name: "@pIdArea", value: empleado.IdArea, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameters.Add(name: "@pEstado", value: empleado.Foto, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add(name: "@pUsuarioModificacion", value: empleado.Foto, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add(name: "@pUsuarioCrea", value: empleado.Foto, dbType: DbType.String, direction: ParameterDirection.Input);


                db.Execute(sql: "SNP_Insertar_T_Empleado", param: parameters, commandType: CommandType.StoredProcedure);

                empleado.IdEmpleado = parameters.Get<int>("@pIdEmpleado");
                if (empleado.IdEmpleado == 0)
                {
                    response.IsSuccess = false; response.ErrorCode = "Solicitud was not created"; response.ErrorMessage = string.Empty;
                    return response;
                }

                response.IsSuccess = true;
                response.ErrorCode = string.Empty;
                response.ErrorMessage = string.Empty;
                response.Data = empleado;
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
