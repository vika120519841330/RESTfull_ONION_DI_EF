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
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly IAccount accountService;
        public AccountController(IAccount _accountService)
        {
            this.accountService = _accountService;
        }

        // GET api/<controller>
        [Route(""), HttpGet]
        public IList<AccountView> GetAll()
        {
            return accountService.GetAll()
                .Select(_ => _.AccountFromDomainToView())
                .ToList();
        }

        // GET api/<controller>/5
        [Route("{id:int}"), HttpGet]
        public AccountView Get([FromUri]int id)
        {
            var temp = accountService.Get(id).AccountFromDomainToView();
            if (temp == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            else return temp;
        }

        // POST api/<controller>
        [Route(""), HttpPost]
        public void Create([FromBody]AccountView inst)
        {
            accountService.Create(inst.AccountFromViewToDomain());
        }

        // PUT api/<controller>
        [Route(""), HttpPut]
        public void Update([FromBody]AccountView inst)
        {
            accountService.Update(inst.AccountFromViewToDomain());
        }

        // DELETE api/<controller>/5
        [Route("{id:int}"), HttpDelete]
        public void Delete([FromUri]int id)
        {
            accountService.Delete(id);
        }
    }
}