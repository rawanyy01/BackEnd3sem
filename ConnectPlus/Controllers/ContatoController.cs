using ConnectPlus.DTO;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContatoController : ControllerBase
{
    
    private IContatoRepository _contatoRepository;
    private IWebHostEnvironment _env;

    public ContatoController(IContatoRepository contatoRepository, IWebHostEnvironment env)
    {
        _contatoRepository = contatoRepository;
        _env = env;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_contatoRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_contatoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }

    }

    [HttpPost]
    public IActionResult Cadastrar([FromForm]ContatoDTO contato)
    {
        try
        {
            string nomeArquivo = string.Empty;

            if (contato.Imagem != null)
            {
                var pasta = Path.Combine(_env.WebRootPath, "Imagens");
                if(!Directory.Exists(pasta)) Directory.CreateDirectory(pasta);

                nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(contato.Imagem.FileName);
                var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                using(var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    contato.Imagem.CopyTo(stream);
                }
            }

            var novoContato = new Contato
            {
                Nome = contato.Nome!,
                DadosContato = contato.DadosContato,
                Imagem = nomeArquivo,
                IdTipoContato = contato.IdTipoContato
            };

            _contatoRepository.Cadastrar(novoContato);
            return StatusCode(201,novoContato);

        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, Contato contato)
    {
        try
        {
            _contatoRepository.Atualizar(id, contato);
            return StatusCode(204, contato);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult delete(Guid id)
    {
        try
        {
            _contatoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

}
