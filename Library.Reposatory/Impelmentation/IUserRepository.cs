﻿using Library.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Reposatory.Impelmentation
{
    public interface IUserRepository
    {
        User FindUserByEmail(string email);
        User FindUserByEmailAndPassword(string email, string password);
    }
}
