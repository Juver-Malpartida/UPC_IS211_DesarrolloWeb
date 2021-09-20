using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IAreaRepository
    {
        BaseResponse<List<EntityArea>> GetAreas();
        BaseResponse<EntityArea> Insert(EntityArea area, char tipoGeneracion);



    }
}
