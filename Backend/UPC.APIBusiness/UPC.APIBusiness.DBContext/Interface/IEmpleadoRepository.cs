using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IEmpleadoRepository
    {
        BaseResponse<List<EntityEmpleadoResponse>> GetEmpleados();
        BaseResponse<EntityEmpleado> InsertEmpleado(EntityEmpleado empleado);
    }
}
