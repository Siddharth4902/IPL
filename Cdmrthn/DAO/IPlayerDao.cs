using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public interface IPlayerDao
    {
        Task<int> InsertPlayer(Player p);
        Task<List<Player>> GetPlayers();
        Task<List<Player>> Top5();

        Task<List<Match>> GetMatch();
        Task<List<Date>> GetMatchesByDate(DateTime date1, DateTime date2);


    }
}
