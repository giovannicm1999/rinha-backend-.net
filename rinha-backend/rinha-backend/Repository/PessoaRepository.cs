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

        public Guid? Save(Pessoa pessoa)
        {
            try
            {
                _context.Pessoas.Add(pessoa);
                _context.SaveChanges();
                return pessoa.Id;
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
                var pessoas = _context.Pessoas.Where(pessoa => pessoa.Apelido.ToLower().Contains(termo.ToLower()) || pessoa.Nome.ToLower().Contains(termo.ToLower()) || pessoa.DbStack.ToLower().Contains(termo.ToLower())).ToList();
                return pessoas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetCount()
        {
            try
            {
                var count = _context.Pessoas.Count();
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

