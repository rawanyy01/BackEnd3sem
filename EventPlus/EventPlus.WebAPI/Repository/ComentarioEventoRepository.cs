using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventPlus.WebAPI.Repository
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly EventContext _context;

        public ComentarioEventoRepository(EventContext context)
        {
            _context = context;
        }

        
        public void Atualizar(ComentarioEvento comentarioEvento)
        {
            var comentarioExistente = _context.ComentarioEventos
                .Find(comentarioEvento.IdComentarioEvento);

            if (comentarioExistente != null)
            {
                comentarioExistente.Descricao = comentarioEvento.Descricao;
                comentarioExistente.Exibe = comentarioEvento.Exibe;
                comentarioExistente.IdEvento = comentarioEvento.IdEvento;
                comentarioExistente.IdUsuario = comentarioEvento.IdUsuario;

                _context.SaveChanges();
            }
        }

        
        public ComentarioEvento BuscarPorIdUsuario(Guid IdUsuario, Guid IdComentarioEvento)
        {
            return _context.ComentarioEventos
                .FirstOrDefault(c =>
                    c.IdUsuario == IdUsuario &&
                    c.IdComentarioEvento == IdComentarioEvento);
        }

        
        public void cadastrar(ComentarioEvento comentarioEvento)
        {
            _context.ComentarioEventos.Add(comentarioEvento);
            _context.SaveChanges();
        }

        
        public void Deletar(Guid IdComentarioEvento)
        {
            var comentario = _context.ComentarioEventos
                .Find(IdComentarioEvento);

            if (comentario != null)
            {
                _context.ComentarioEventos.Remove(comentario);
                _context.SaveChanges();
            }
        }

        
        public List<ComentarioEvento> List(Guid IdEvento)
        {
            return _context.ComentarioEventos
                .Where(c => c.IdEvento == IdEvento)
                .ToList();
        }

               public List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento)
        {
            return _context.ComentarioEventos
                .Include(c => c.IdEventoNavigation)
                .Include(c => c.IdUsuarioNavigation)
                .Where(c => c.IdEvento == IdEvento && c.Exibe)
                .ToList();
        }
    }
}