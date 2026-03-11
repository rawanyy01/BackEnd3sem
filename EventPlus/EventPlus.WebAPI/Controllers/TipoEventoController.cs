using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoEventoController : ControllerBase
{
    private ITipoEventoRepository _tipoEventoRepository;

    public TipoEventoController(ITipoEventoRepository tipoEventoRepository)
    {
        _tipoEventoRepository = tipoEventoRepository;
    }

    /// <summary>
    /// Endpoint da api que faz a chamda para o método de listar os tipos de evento
    /// </summary>
    /// <returns>status code 200 e a lista do tipo de eventos</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_tipoEventoRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da api faz a chanda para o metodo de buscar um tipo de evento especifico
    /// </summary>
    /// <param name="id">Id do tipo de evento buscado</param>
    /// <returns>status code 200 e o tipo de evento buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_tipoEventoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }

    }

    /// <summary>
    /// Endpoint da api q faz chamada para o metodo de cadastrar um tipo de evento
    /// </summary>
    /// <param name="tipoEvento">tipo de evento a ser cadastrado</param>
    /// <returns>code 201 e tipo de evento a ser cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(TipoEventoDTO tipoEvento)
    {
        try
        {

            var novoTipoEvento = new TipoEvento
            {
                Titulo = tipoEvento.Titulo!
            };

            _tipoEventoRepository.Cadastrar(novoTipoEvento);
            return StatusCode(201, tipoEvento);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoind da api q faz a chamada para o metodo atualizar o tipo evento
    /// </summary>
    /// <param name="id">Id do tipo evento a seer atualizado</param>
    /// <param name="tipoEvento">tipo de evento com os dados atualizados</param>
    /// <returns>status code 204 e o tipo de evento atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, TipoEvento tipoEvento)
    {
        try
        {
            _tipoEventoRepository.Atualizar(id, tipoEvento);
            return StatusCode(204, tipoEvento);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoind da api q faz a chamada para o metodo Deletar o tipo evento
    /// </summary>
    /// <param name="id">Id do tipo evento a seer excluido</param>
    /// <returns>status code 204 e o tipo de evento excluido</returns>
    [HttpDelete("{id}")]
    public IActionResult delete(Guid id)
    {
        try
        {
            _tipoEventoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }
}
