using ClientAccount_Onion_EF_WebApi.Models;
using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using ClientAccount_Onion_EF_WebApi.Mappers;

namespace ClientAccount_Onion_EF_WebApi.Controllers
{
    [RoutePrefix("api/client")]
    public class ClientController : ApiController
    {
        private readonly IClient clientService;
        public ClientController(IClient _clientService)
        {
            this.clientService = _clientService;
        }

        // GET api/<controller>
        [Route(""), HttpGet]
        public IList<ClientView> GetAll()
        {
            return clientService.GetAll()
                .Select(_ => _.ClientFromDomainToView())
                .ToList();
        }

        // GET api/<controller>/5
        [Route("{id:int}"), HttpGet]
        public ClientView Get([FromUri]int id)
        {
            var temp = clientService.Get(id).ClientFromDomainToView();
            if (temp == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            else return temp;
        }

        // POST api/<controller>
        [Route(""), HttpPost]
        public void Create([FromBody]ClientView inst)
        {
            clientService.Create(inst.ClientFromViewToDomain());
        }

        // PUT api/<controller>
        [Route(""), HttpPut]
        public void Update([FromBody]ClientView inst)
        {
            clientService.Update(inst.ClientFromViewToDomain());
        }

        // DELETE api/<controller>/5
        [Route("{id:int}"), HttpDelete]
        public void Delete([FromUri]int id)
        {
            clientService.Delete(id);
        }
    }
}