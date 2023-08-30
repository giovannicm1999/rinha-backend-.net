using System;
using Microsoft.AspNetCore.Mvc;
using rinha_backend.Entity;
using rinha_backend.Repository;

namespace rinha_backend.Controllers
{
    [ApiController]
    public class PessoaController : ControllerBase
    {

        IPessoaRepository _repository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _repository = pessoaRepository;
        }

        [HttpPost("pessoas")]
        public IActionResult Post(Pessoa pessoa)
        {
            try
            {
                if (String.IsNullOrEmpty(pessoa.Nome) || String.IsNullOrEmpty(pessoa.Apelido))
                    throw new Exception("requisição inválida");

                var guid = _repository.Save(pessoa);
                Response.Headers.Add("Location", $"/pessoas/{guid}");
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(422, ex.Message);
            }
        }

        [HttpGet("pessoas/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var pessoa = _repository.GetById(id);
                if (pessoa == null)
                    return StatusCode(404);

                return StatusCode(200, pessoa);
            }
            catch (Exception ex)
            {
                return StatusCode(422, ex.Message);
            }
        }

        [HttpGet("pessoas")]
        public IActionResult GetByTerm(string t)
        {
            try
            {
                var pessoas = _repository.GetByTerm(t);
                return StatusCode(200, pessoas);
            }
            catch (Exception ex)
            {
                return StatusCode(422, ex.Message);
            }
        }

        [HttpGet("contagem-pessoas")]
        public IActionResult GetCount()
        {
            try
            {
                var count = _repository.GetCount();
                return StatusCode(200, count);
            }
            catch (Exception ex)
            {
                return StatusCode(422, ex.Message);
            }
        }
    }
}

