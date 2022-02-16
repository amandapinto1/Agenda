using Agenda.Model;
using Agendamento.Data.Repositorios.Interfaces;
using Agendamento.Services.Interfaces;

namespace Agendamento.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepositorio;

        public ContatoService(IContatoRepository contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public void Adicionar(Contato contato)
        {
            var contatoExistente = _contatoRepositorio.BuscarPorNome(contato.Nome);

            if (contatoExistente != null)
                throw new Exception("Já existe um Contato com esse nome");

            var contatoNovo = new Contato(
                contato.Nome,
                contato.Telefone,
                contato.Email);

            _contatoRepositorio.Adicionar(contato);
        }
        public void Editar(Contato contato)
        {
                _contatoRepositorio.Editar(contato);

        }

        public IEnumerable<Contato> GetContatos() => _contatoRepositorio.GetContatos().ToList();

        public async Task<IEnumerable<Contato>> BuscarPorNome(string nome) => await _contatoRepositorio.BuscarPorNome(nome);


    }
}
