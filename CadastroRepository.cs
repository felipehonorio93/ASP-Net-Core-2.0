using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{

    public interface ICadastroRepository
    {
        Cadastro Upadate(int cadastroId, Cadastro novoCadastro);
    }
    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public Cadastro Upadate(int cadastroId, Cadastro novoCadastro)
        {
            var cadastroDB = dbSet.
                  Where(c => c.Id == cadastroId)
                  .SingleOrDefault();

            if (cadastroDB== null)
            { 
                throw new ArgumentNullException("Cadastro");
            }
            cadastroDB.Update(novoCadastro);
            contexto.SaveChanges();

            return cadastroDB;
        }
    }
}
