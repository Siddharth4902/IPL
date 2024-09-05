using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Date
    {
        public int match_id {  get; set; }
        public string venue {  get; set; }
        public DateTime match_date { get; set; }
        public string team1 { get; set; }
        public string team2 { get; set; }
    }
}
