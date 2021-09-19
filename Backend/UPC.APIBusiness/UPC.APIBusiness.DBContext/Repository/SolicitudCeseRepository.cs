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
        public List<EntitySolicitudCese> GetSolicitudes()
        {
            var returnEntity = new List<EntitySolicitudCese>();
            using (var db = GetSqlConnection())
            {
                const string sql = @"SNP_Consulta_T_SolicitudSede";
                returnEntity = db.Query<EntitySolicitudCese>(sql, commandType: CommandType.StoredProcedure).ToList();
            }
            return returnEntity;
        }
    }
}
