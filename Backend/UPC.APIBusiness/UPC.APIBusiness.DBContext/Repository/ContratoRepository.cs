using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class ContratoRepository : BaseRepository, IContratoRepository
    {
        public BaseResponse<List<EntityContrato>> GetContratos()
        {
            var response = new BaseResponse<List<EntityContrato>>();

            try
            {
                using var db = GetSqlConnection();
                List<EntityContrato> returnEntity = db.Query<EntityContrato>("SNP_Consulta_T_Contrato", commandType: CommandType.StoredProcedure).ToList();
                response.IsSuccess = true;
                response.ErrorCode = string.Empty;
                response.ErrorMessage = string.Empty;
                response.Data = returnEntity;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorCode = "Unknown error";
                response.ErrorMessage = ex.Message;
                response.Data = (List<EntityContrato>)Enumerable.Empty<EntityContrato>();
            }
            return response;
        }

        public BaseResponse<EntityContrato> Insert(EntityContrato contrato, char tipoGeneracion)
        {
            var response = new BaseResponse<EntityContrato>();
            try
            {
                using var db = GetSqlConnection();

                var parameters = new DynamicParameters();
                parameters.Add(name: "@pIdContrato", dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
                parameters.Add(name: "@pTipoGeneracion", value: tipoGeneracion, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add(name: "@pNumeroContrato", value: contrato.NumeroContrato, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add(name: "@pFechaInicioCont", value: contrato.FechaInicioCont, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                parameters.Add(name: "@pFechaFinCont", value: contrato.FechaFinCont, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                parameters.Add(name: "@pFechaRegistroCont", value: contrato.FechaRegistroCont, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                parameters.Add(name: "@pSueldoActual", value: contrato.SueldoActual, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                parameters.Add(name: "@pMonedaPago", value: contrato.MonedaPago, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add(name: "@pIdEmpleado", value: contrato.IdEmpleado, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameters.Add(name: "@pEstado", value: contrato.Estado, dbType: DbType.String, direction: ParameterDirection.Input);
                parameters.Add(name: "@pUsuarioModificacion", value: 1, dbType: DbType.String, direction: ParameterDirection.Input);

                db.Execute("SNP_Insertar_T_Contrato", commandType: CommandType.StoredProcedure, param: parameters);

                if (contrato.IdContrato == 0) contrato.IdContrato= parameters.Get<int>("@pIdContrato");

                response.IsSuccess = true;
                response.ErrorCode = string.Empty;
                response.ErrorMessage = string.Empty;
                response.Data = contrato;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorCode = "Unknown error";
                response.ErrorMessage = ex.Message;
                response.Data = null;
            }
            return response;
        }
    }
}
