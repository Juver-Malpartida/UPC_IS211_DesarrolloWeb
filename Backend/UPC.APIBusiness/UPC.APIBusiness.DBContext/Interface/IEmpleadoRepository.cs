﻿using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IEmpleadoRepository
    {
        BaseResponse<List<EntityEmpleado>> GetEmpleados();
        BaseResponse<EntityEmpleado> InsertEmpleado(EntityEmpleado empleado);
    }
}
