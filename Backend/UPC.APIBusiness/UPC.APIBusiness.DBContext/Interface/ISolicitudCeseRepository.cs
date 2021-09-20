using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface ISolicitudCeseRepository
    {
        BaseResponse<List<EntitySolicitudCese>> GetSolicitudes();
        BaseResponse<EntitySolicitudCese> GetSolicitud(int id);
        BaseResponse<EntitySolicitudCese> Insert(EntitySolicitudCese solicitudCese);
    }
}
