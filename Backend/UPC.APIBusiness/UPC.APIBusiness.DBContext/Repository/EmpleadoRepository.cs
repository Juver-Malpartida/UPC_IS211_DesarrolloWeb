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
        public List<EntityEmpleado> GetEmpleados()
        {
            var returnEntity = new List<EntityEmpleado>();
            using (var db = GetSqlConnection())
            {
                const string sql = @"SNP_Consulta_T_Empleado";


                returnEntity = db.Query<EntityEmpleado>(sql, commandType: CommandType.StoredProcedure).ToList();
            }
            return returnEntity;
        }
    }
}
