using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Match
    {
        public int match_id {  get; set; }
        public string venue { get; set; }
        public string team1 { get; set; }
        public string team2 { get; set; }
        
        public DateTime date { get; set; }
        public int fan { get; set; }
    }
}
