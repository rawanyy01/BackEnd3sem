using ConnectPlus.DTO;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoContatoController : ControllerBase
    {
        private ITipoContatoRepository _tipoContatoRepository;

        public TipoContatoController(ITipoContatoRepository tipoContatoRepository)
        {
            _tipoContatoRepository = tipoContatoRepository;
        }

        /// <summary>
        /// Lista todos os tipos de contato cadastrados
        /// </summary>
        /// <returns>Lista de tipos de contato</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_tipoContatoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um tipo de contato específico pelo seu ID
        /// </summary>
        /// <param name="id">ID do tipo de contato</param>
        /// <returns>Objeto do tipo de contato encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                return Ok(_tipoContatoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo tipo de contato
        /// </summary>
        /// <param name="tipoContato">Dados do tipo de contato (DTO)</param>
        /// <returns>Objeto criado</returns>
        [HttpPost]
        public IActionResult Cadastrar(TipoContatoDTO tipoContato)
        {
            try
            {
                var novoTipoContato = new TipoContato
                {
                   
                    Titulo = tipoContato.Titulo!
                };

                _tipoContatoRepository.Cadastrar(novoTipoContato);
                return StatusCode(201, novoTipoContato);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza um tipo de contato existente
        /// </summary>
        /// <param name="id">ID do tipo de contato a ser atualizado</param>
        /// <param name="tipoContato">Novos dados do tipo de contato</param>
        /// <returns>Status Code 204 (No Content)</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, TipoContato tipoContato)
        {
            try
            {
                var tipoContatoAtualizado = new TipoContato
                {
                    Titulo = tipoContato.Titulo!
                };

                _tipoContatoRepository.Atualizar(id, tipoContatoAtualizado);
                return StatusCode(204, tipoContatoAtualizado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um tipo de contato
        /// </summary>
        /// <param name="id">ID do tipo de contato a ser deletado</param>
        /// <returns>Status Code 204 (No Content)</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                _tipoContatoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}