using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class AreaRepository : BaseRepository, IAreaRepository
    {
        public BaseResponse<List<EntityArea>> GetAreas()
        {
            var response = new BaseResponse<List<EntityArea>>();

            try
            {
                using var db = GetSqlConnection();
                List<EntityArea> returnEntity = db.Query<EntityArea>("SNP_Consulta_T_AREA", commandType: CommandType.StoredProcedure).ToList();
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
                response.Data = (List<EntityArea>)Enumerable.Empty<EntityArea>();
            }
            return response;
        }

        public BaseResponse<EntityArea> Insert(EntityArea area, char tipoGeneracion)
        {
            var response = new BaseResponse<EntityArea>();
            try
            {
                using var db = GetSqlConnection();

                var p = new DynamicParameters();
                p.Add(name: "@pIdArea", dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add(name: "@pTipoGeneracion", value: tipoGeneracion, dbType: DbType.String, direction: ParameterDirection.Input);
                p.Add(name: "@pDescripcion", value: area.Descripcion, dbType: DbType.String, direction: ParameterDirection.Input);
                p.Add(name: "@pIdIprArea", value: area.IdIprArea, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add(name: "@pEstado", value: area.Estado, dbType: DbType.String, direction: ParameterDirection.Input);
                p.Add(name: "@pUsuarioModificacion", value: 1, dbType: DbType.String, direction: ParameterDirection.Input);

                db.Execute("SNP_Insertar_T_Area", commandType: CommandType.StoredProcedure, param: p);

                //area.IdArea = p.Get<int>("@pIdArea");

                response.IsSuccess = true;
                response.ErrorCode = string.Empty;
                response.ErrorMessage = string.Empty;
                response.Data = area;
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
