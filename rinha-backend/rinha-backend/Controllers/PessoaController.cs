using System;
using Microsoft.AspNetCore.Mvc;
using rinha_backend.Entity;
using rinha_backend.Repository;

namespace rinha_backend.Controllers
{
    [ApiController]
    [Route("pessoas")]
    public class PessoaController : ControllerBase
    {

        IPessoaRepository _repository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _repository = pessoaRepository;
        }

        [HttpPost]
        public IActionResult Post(Pessoa pessoa)
        {
            try
            {
                _repository.Save(pessoa);
                return StatusCode(200, "Ok");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var pessoa = _repository.GetById(id);
                return StatusCode(200, pessoa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet()]
        public IActionResult GetByTerm(string t)
        {
            try
            {
                var pessoas = _repository.GetByTerm(t);
                return StatusCode(200, pessoas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

