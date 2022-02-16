using Agenda.Model;

namespace Agendamento.Services.Interfaces
{
    public interface IContatoService
    {
        public void Adicionar(Contato contato);
        public void Editar(Contato contato);
        IEnumerable<Contato> GetContatos();
        Task<IEnumerable<Contato>> BuscarPorNome(string nome);


    }
}
