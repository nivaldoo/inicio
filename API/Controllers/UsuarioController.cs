using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        //public IEnumerable<UsuarioViewModel> Get()
        public IHttpActionResult Get()
        {
            return Ok(UsuarioModel.Usuarios());
        }

        // GET: api/Usuario/5
        public IHttpActionResult Get(string id, string nome, string cpf)
        {
            //return Ok(UsuarioModel.Usuario(id)); //Um só
            var filter = new UsuarioViewModel { Id = id, Nome = nome, CPF = cpf };
            return Ok(UsuarioModel.Usuarios(filter));
            //return "value";
        }

        // POST: api/Usuario
        public void Post([FromBody]dynamic value)
        {
        }

        // PUT: api/Usuario/5
        public void Put(string id, [FromBody]dynamic value)
        {
        }

        // DELETE: api/Usuario/5
        public void Delete(string id)
        {
            //throw new Exception("Errou");
        }

        [HttpPost]
        [Route("api/Usuario/Outro")]
        public IHttpActionResult Outro([FromBody]dynamic value)
        {
            return Ok(value);
        }
    }
}
