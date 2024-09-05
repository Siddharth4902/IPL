using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Player
    {
        public int player_id { get; set; }
        public string player_name { get; set; }
        public int team_id {  get; set; }
        public string role {  get; set; }
        public int age { get; set; }
        public int matches_played {  get; set; }

    }
   
    
}
