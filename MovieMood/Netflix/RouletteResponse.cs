using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMood.Netflix
{
    public class RouletteResponse
    {
        public int unit { get; set; }
        public int show_id { get; set; }
        public string show_title { get; set; }
        public string release_year { get; set; }
        public string rating { get; set; }
        public string category { get; set; }
        public string show_cast { get; set; }
        public string director { get; set; }
        public string summary { get; set; }
        public string poster { get; set; }
        public int mediatype { get; set; }
        public string runtime { get; set; }
        public int canada { get; set; }
        public int united_states { get; set; }
        public bool error { get; set; }
    }
}
