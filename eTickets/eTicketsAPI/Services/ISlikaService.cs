﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Model;
using eTickets.Model.Requests;

namespace eTicketsAPI.Services
{
    public interface ISlikaService :
        ICrudService<eTickets.Model.Slika, object,SlikaInsertRequest,object>
    {
        
    }
}
