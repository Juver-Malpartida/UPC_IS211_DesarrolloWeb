﻿using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IUserRepository
    {
        BaseResponse<EntityUser> Insert(EntityUser user);
        BaseResponse<EntityLoginResponse> Login(EntityLoginRequest login);
    }
}
