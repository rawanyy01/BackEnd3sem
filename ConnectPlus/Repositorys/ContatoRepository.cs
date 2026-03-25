using ConnectPlus.Data;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly AppDbContext _context;


        public ContatoRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Contato> Listar()
        {

            return _context.Contatos.Include(c => c.IdTipoContatoNavigation).ToList();
        }

        public Contato BuscarPorId(Guid id)
        {
            return _context.Contatos
                .Include(c => c.IdTipoContatoNavigation)
                .FirstOrDefault(c => c.IdContato == id);
        }

        public void Cadastrar(Contato contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
        }

        public void Atualizar(Guid id, Contato contato)
        {
            var contatoExistente = _context.Contatos.Find(id);

            if (contatoExistente != null)
            {

                contatoExistente.Nome = contato.Nome;
                contatoExistente.FormaContato = contato.FormaContato;
                contatoExistente.Imagem = contato.Imagem;
                contatoExistente.IdTipoContato = contato.IdTipoContato;

                _context.Contatos.Update(contatoExistente);
                _context.SaveChanges();
            }
        }

        public void Deletar(Guid id)
        {
            var contatoParaRemover = _context.Contatos.Find(id);

            if (contatoParaRemover != null)
            {
                _context.Contatos.Remove(contatoParaRemover);
                _context.SaveChanges();
            }
        }
    }
}