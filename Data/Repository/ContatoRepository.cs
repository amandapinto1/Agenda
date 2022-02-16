using Agenda.Model;
using Agendamento.Data.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data.Repositorios
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ContatoContexto _context;
        public ContatoRepository(ContatoContexto context)
        {
            _context = context;
        }
        public void Adicionar(Contato contato)
        {
            _context.Contato.Add(contato);
            _context.SaveChanges();
        }

        public void Editar(Contato contato)
        {
            _context.Update(contato);
            _context.SaveChanges();
        }

        public void Excluir(Guid id)
        {
            _context.RemoveRange(id);
            _context.SaveChanges();

        }

        public IEnumerable<Contato> GetContatos()
        {
            return _context.Contato.ToList();
        }

        public async Task<IEnumerable<Contato>> BuscarPorNome(string nome)
        {
            IQueryable<Contato> query = _context.Contato;

            if(!string.IsNullOrEmpty(nome))
            {
                query = query.Where(n => n.Nome.Contains(nome));
            }
            return await query.ToListAsync();

        }
    }
}
