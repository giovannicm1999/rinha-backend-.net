using System;
using Microsoft.EntityFrameworkCore;
using rinha_backend.Context;
using rinha_backend.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace rinha_backend.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly RinhaContext _context;

        public PessoaRepository(RinhaContext context)
        {
            _context = context;
        }

        public void Save(Pessoa pessoa)
        {
            try
            {
                _context.Add(pessoa);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Pessoa GetById(Guid id)
        {
            try
            {
                var pessoa = _context.Pessoas.Find(id);
                return pessoa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Pessoa> GetByTerm(string termo)
        {
            try
            {
                var pessoas = _context.Pessoas.Where(pessoa => pessoa.Apelido.Contains(termo) || pessoa.Nome.Contains(termo) || pessoa.Stack.Any(s => EF.Functions.Like(termo, s))).ToList();
                return pessoas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

