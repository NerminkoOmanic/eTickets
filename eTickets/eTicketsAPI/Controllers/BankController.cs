﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Model;
using eTickets.Model.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eTicketsAPI.Database;
using eTicketsAPI.Services;
using Microsoft.AspNetCore.Authorization;

namespace eTicketsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;

        public BankController([FromQuery]IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet]
        public bool Get([FromQuery] BankAccountRequest request)
        {
            return _bankService.Get(request);
        }

        [HttpPost]
        public eTickets.Model.BankTransaction Insert([FromBody]OnlinePaymentRequest request)
        {
            return _bankService.Insert(request);
        }


    }
}
