using Agenda.Model;

namespace Agendamento.Data.Repositorios.Interfaces
{
    public interface IContatoRepository
    {
        void Adicionar(Contato contato);
        void Excluir(Guid id);
        void Editar(Contato contato);
        IEnumerable<Contato> GetContatos();
        Task<IEnumerable<Contato>> BuscarPorNome(string nome);
    }
}
