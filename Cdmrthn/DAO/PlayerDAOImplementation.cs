using Npgsql;
using WebApplication1.Models;
using System.Data;
using NpgsqlTypes;
using System.Diagnostics.Metrics;
using System.Numerics;
namespace WebApplication1.DAO
{
    public class PlayerDAOImplementation: IPlayerDao
    {
        private readonly NpgsqlConnection _connection;
        public PlayerDAOImplementation(NpgsqlConnection connection)
        {
            _connection = connection;
        }
        public async Task<List<Player>> GetPlayers()
        {
            string query = @" select * from ipl.players ";
            List<Player> players = new List<Player>();
            Player player = null;
            try
            {
                using (_connection)
                {
                    await _connection.OpenAsync();
                    NpgsqlCommand Command = new NpgsqlCommand(query, _connection);
                    Command.CommandType = CommandType.Text;
                    //Command.Parameters.AddWithValue("@pid", id);
                    NpgsqlDataReader reader = await Command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            player = new Player();
                            player.player_id = reader.GetInt32(0);
                            player.player_name = reader.GetString(1);
                            player.team_id = reader.GetInt32(2);
                            player.role = reader.GetString(3);
                            player.age = reader.GetInt32(4);
                            player.matches_played = reader.GetInt32(5);
                            players.Add(player);

                        }

                    }
                    reader?.Close();
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine("------Exception-----" + e.Message);
            }
            return players;

        }
        public async Task<List<Player>> Top5()
        {
            string query = @"
                select 
                    p.*, sum(f.engagement_id) as total_fan_engagements
                from 
                    ipl.players p
                join 
                    ipl.matches m on p.team_id = m.team1_id or p.team_id = m.team2_id
                left join 
                    ipl.fan_engagement f on m.match_id = f.match_id
                group by 
                    p.player_id, p.player_name, p.matches_played
                order by 
                    p.matches_played desc, total_fan_engagements desc
                limit 5";
            List<Player> players = new List<Player>();
            Player player = null;
            try
            {
                using (_connection)
                {
                    await _connection.OpenAsync();
                    NpgsqlCommand Command = new NpgsqlCommand(query, _connection);
                    Command.CommandType = CommandType.Text;
                    //Command.Parameters.AddWithValue("@pid", id);
                    NpgsqlDataReader reader = await Command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            player = new Player();
                            player.player_id = reader.GetInt32(0);
                            player.player_name = reader.GetString(1);
                            player.team_id = reader.GetInt32(2);
                            player.role = reader.GetString(3);
                            player.age = reader.GetInt32(4);
                            player.matches_played = reader.GetInt32(5);
                            players.Add(player);

                        }

                    }
                    reader?.Close();
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine("------Exception-----" + e.Message);
            }
            return players;

        }

        public async Task<List<Match>> GetMatch()
        {
            string query = @" select m.match_id, m.venue,  t1.team_name, t2.team_name, match_date, count(f.match_id) from ipl.matches m 
                        left join ipl.fan_Engagement f on f.match_id = m.match_id 
                        join ipl.teams t1 on t1.team_id = m.team1_id 
                        join ipl.teams t2 on t2.team_id = m.team2_id      
                        group by m.match_id, venue, f.match_id, match_date,  t1.team_id, t2.team_id
                        order by m.match_id";


            List<Match> matches = new List<Match>();
            Match match = null;
            try
            {
                using (_connection)
                {
                    await _connection.OpenAsync();
                    NpgsqlCommand Command = new NpgsqlCommand(query, _connection);
                    Command.CommandType = CommandType.Text;
                    NpgsqlDataReader reader = await Command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            match = new Match();
                            match.match_id = reader.GetInt32(0);
                            match.venue = reader.GetString(1);
                            match.team1=reader.GetString(2);
                            match.team2 = reader.GetString(3);
                            match.date = reader.GetDateTime(4);
                            match.fan = reader.GetInt32(5);
                            matches.Add(match);


                        }

                    }
                    reader?.Close();
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine("------Exception-----" + e.Message);
            }
            return matches;

        }
        public async Task<int> InsertPlayer(Player p)
        {
            int rowsInserted = 0;
            string message;
            string insertQuery = $"insert into ipl.players (player_name, team_id, role, age, matches_played) VALUES ('{p.player_name}',{p.team_id},'{p.role}',{p.age},'{p.matches_played}'  )";
            Console.WriteLine("Query"+insertQuery);
            try
            {
                using (_connection)
                {
                    await _connection.OpenAsync();
                    NpgsqlCommand Command = new NpgsqlCommand(insertQuery, _connection);
                    Command.CommandType = CommandType.Text;
                    rowsInserted = await Command.ExecuteNonQueryAsync();
                }
            }
            catch (NpgsqlException e) 
            {
                message = e.Message;
                Console.WriteLine("------Exception-----"+message);
            }
                return rowsInserted;
        }

        public async Task<List<Date>>GetMatchesByDate(DateTime date1, DateTime date2)
        {
            string query = @"select match_id, venue, match_date, t1.team_name, t2.team_name from ipl.matches m
	join ipl.teams t1 on t1.team_id = m.team1_id
	join ipl.teams t2 on t2.team_id = m.team2_id
	where match_date between @date1 and @date2
	group by match_id, venue, match_date, t1.team_id, t2.team_id;";
            List<Date> matches = new List<Date>();
            Date match = null;
            try
            {
                using (_connection)
                {
                    await _connection.OpenAsync();
                    NpgsqlCommand Command = new NpgsqlCommand(query, _connection);
                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue("date1", date1);
                    Command.Parameters.AddWithValue("date2", date2);

                    NpgsqlDataReader reader = await Command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            match = new Date();
                            match.match_id = reader.GetInt32(0);
                            match.venue = reader.GetString(1);
                            match.match_date = reader.GetDateTime(2);
                            match.team1 = reader.GetString(3);
                            match.team2 = reader.GetString(4);
                            matches.Add(match);


                        }

                    }
                    reader?.Close();
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine("------Exception-----" + e.Message);
            }
            return matches;
        }

    }
}
