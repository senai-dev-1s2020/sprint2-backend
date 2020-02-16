using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.filmes.webapi.Domains;
using senai.filmes.webapi.Interfaces;
using senai.filmes.webapi.Repositories;

namespace senai.filmes.webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private IGeneroRepository _generoRepository { get; set; }

        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        [HttpGet]
        public IEnumerable<GeneroDomain> Get()
        {
            return _generoRepository.Listar();
        }
    }
}