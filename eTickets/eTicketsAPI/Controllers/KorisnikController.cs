﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikService _korisnikService;
        public KorisnikController(IKorisnikService korisnikService)
        {
            _korisnikService = korisnikService;
        }

    
        [HttpGet]
        public IEnumerable<eTickets.Model.Korisnik> Get([FromQuery] KorisnikSearchRequest request)
        {
            return _korisnikService.Get(request);
        }

        [HttpGet("{id}")]
        [Authorize]
        public eTickets.Model.Korisnik GetById(int id)
        {
            return _korisnikService.GetById(id);
        }

        [HttpPost]
        public eTickets.Model.Korisnik Insert([FromBody]KorisnikInsertRequest request)
        {
            return _korisnikService.Insert(request);
        }

        [HttpPut("{id}")]
        [Authorize]
        public eTickets.Model.Korisnik Update(int id, [FromBody] KorisnikUpdateRequest request)
        {
            return _korisnikService.Update(id, request);
        }

        [HttpGet("profil")]
        [Authorize]
        public eTickets.Model.Korisnik Profil()
        {
            return _korisnikService.Profil();
        }
    }
}
