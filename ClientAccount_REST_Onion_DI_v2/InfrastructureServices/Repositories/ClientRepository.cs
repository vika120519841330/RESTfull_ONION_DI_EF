﻿using System;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Infrastructure.Interfaces;
using InfrastructureServices.Contexts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web.Http;

namespace InfrastructureServices.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly MyContext context;
        public ClientRepository(MyContext _context)
        {
            this.context = _context;
        }
        public IList<ClientInfrastr> GetAllCl()
        {
            return context.Clients
                   .Include(_ => _.AccountsOfClient)
                   .ToList()
                   ;
        }

        public ClientInfrastr GetCl(int id)
        {
            var temp = context.Clients.Find(id);
            if (temp == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return temp;
            }
        }

        public void CreateCl(ClientInfrastr inst)
        {
            context.Clients.Add(inst);
            context.SaveChanges();
        }

        public void UpdateCl(ClientInfrastr inst)
        {
            var temp = context.Clients.Find(inst.ClientId);
            if (temp != null)
            {
                context.Entry(inst).State = EntityState.Modified;
                context.SaveChanges();
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        public void DeleteCl(int id)
        {
            var tmp = context.Clients.Find(id);
            if (tmp != null)
            {
                context.Clients.Remove(tmp);
                context.SaveChanges();
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}