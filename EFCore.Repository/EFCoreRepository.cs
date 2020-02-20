using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repository
{
    public class EFCoreRepository : IEFCoreRepository
    {
        private readonly JogoContext _context;

        public EFCoreRepository(JogoContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Jogo[]> GetAllJogos(bool incluirConsole = false)
        {
            IQueryable<Jogo> query = _context.Jogos
                .Include(h => h.GeneroId)
                .Include(h => h.ClassificacaoId);

            if (incluirConsole)
            {
                query = query.Include(h => h.JogosConsoles).ThenInclude(jogoc => jogoc.VideoGames);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Jogo> GetJogoById(int id, bool incluirConsole = false)
        {
            IQueryable<Jogo> query = _context.Jogos
                .Include(h => h.GeneroId)
                .Include(h => h.ClassificacaoId);

            if (incluirConsole)
            {
                query = query.Include(h => h.JogosConsoles).ThenInclude(jogoc => jogoc.VideoGames);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<Jogo[]> GetJogoByNome(string nome, bool incluirConsole = false)
        {
            IQueryable<Jogo> query = _context.Jogos
                .Include(h => h.GeneroId)
                .Include(h => h.ClassificacaoId);

            if (incluirConsole)
            {
                query = query.Include(h => h.JogosConsoles).ThenInclude(jogoc => jogoc.VideoGames);
            }

            query = query.AsNoTracking().Where(h => h.Nome.Contains(nome)).OrderBy(h => h.Id);

            return await query.ToArrayAsync();
        }

        public async Task<VideoGame[]> GetAllConsole(bool incluirJogos = false)
        {
            IQueryable<VideoGame> query = _context.VideoGames;

            if (incluirJogos)
            {
                query = query.Include(h => h.JogosConsoles).ThenInclude(jogoc => jogoc.Jogos);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.ToArrayAsync();
        }

        public async Task<VideoGame> GetConsoleById(int id, bool incluirJogos = false)
        {
            IQueryable<VideoGame> query = _context.VideoGames;

            if (incluirJogos)
            {
                query = query.Include(h => h.JogosConsoles).ThenInclude(jogoc => jogoc.Jogos);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
