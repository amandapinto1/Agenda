using Agenda.Model;
using Agendamento.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Agenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : Controller
    {
        private readonly IContatoService _services;

        public ContatoController(IContatoService service)
        {
            _services = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contato>> GetContatos()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Entidade Inválida");
                }
                else
                {
                    var contatos = _services.GetContatos();
                    return Json(contatos);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Contato contato)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Entidade Inválida");
                }
                else
                {
                    _services.Adicionar(contato);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("editar")]
        public IActionResult Editar([FromBody] Contato contato)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Entidade Inválida");
                }
                else
                {
                    _services.Editar(contato);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("{buscanome}")]
        public async Task<ActionResult<IEnumerable<Contato>>> BuscarPorNome(string nome)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var contatos = await _services.BuscarPorNome(nome);
                    if (contatos.Any())
                    {
                        return Ok(contatos);
                    }
                    return NotFound();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            else
            {
                return BadRequest("Entidade Inválida");
            }
        }
    }
}
