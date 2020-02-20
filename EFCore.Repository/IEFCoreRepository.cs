using EFCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repository
{
    public interface IEFCoreRepository 
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;


        Task<bool> SaveChangesAsync();

        Task<Jogo[]> GetAllJogos(bool incluirConsole = false);
        Task<Jogo> GetJogoById(int id, bool incluirConsole = false);
        Task<Jogo[]> GetJogoByNome(string nome, bool incluirConsole = false);

        Task<VideoGame[]> GetAllConsole(bool incluirConsole = false);
        Task<VideoGame> GetConsoleById(int id, bool incluirConsole = false);
    }
}
