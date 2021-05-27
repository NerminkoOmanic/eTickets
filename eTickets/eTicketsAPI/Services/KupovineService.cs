﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTickets.Model;
using eTickets.Model.Requests;
using eTicketsAPI.Database;
using Microsoft.EntityFrameworkCore;
using Ticket = eTickets.Model.Ticket;

namespace eTicketsAPI.Services
{
    public class KupovineService : IKupovineService
    {
        public IB3012Context Context { get; set; }
        protected readonly IMapper _mapper;
        public KupovineService(IB3012Context context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public IEnumerable<KupovineDgvExtension> Get()
        {
            var list = Context.Kupovine.Include(x=>x.Ticket)
                .Include(x=>x.Kupac)
                .Include(x=>x.Ticket.Prodavac).ToList();
            
            return _mapper.Map<List<KupovineDgvExtension>>(list);
        }


        public eTickets.Model.Kupovine GetById(int id)
        {
            var entity = Context.Kupovine.Include(x => x.Kupac)
                .Include(x => x.Ticket)
                .Include(x => x.Ticket.Prodavac)
                .FirstOrDefault(x=>x.TicketId == id);

            return _mapper.Map<eTickets.Model.Kupovine>(entity);
        }

        public eTickets.Model.Kupovine Insert(KupovineInsertRequest request)
        {
            var entity = new Database.Kupovine();

            _mapper.Map(request, entity);

            Context.Kupovine.Add(entity);
            Context.SaveChanges();
            return _mapper.Map<eTickets.Model.Kupovine>(entity);
        }

    }
}
