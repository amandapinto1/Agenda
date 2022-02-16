using System.ComponentModel.DataAnnotations;

namespace Agenda.Model
{
    public class Contato
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        public Contato(string nome, string telefone, string email)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
        }
    }
}
