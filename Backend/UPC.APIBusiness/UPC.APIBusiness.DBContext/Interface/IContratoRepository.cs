using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IContratoRepository
    {
        BaseResponse<List<EntityContrato>> GetContratos();
        BaseResponse<EntityContrato> Insert(EntityContrato contrato, char tipoGeneracion);
    }
}
