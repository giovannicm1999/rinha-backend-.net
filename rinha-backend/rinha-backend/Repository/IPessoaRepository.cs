using System;
using rinha_backend.Entity;

namespace rinha_backend.Repository
{
    public interface IPessoaRepository
    {
        public void Save(Pessoa pessoa);
        public Pessoa GetById(Guid id);
        public List<Pessoa> GetByTerm(string termo);
    }
}

