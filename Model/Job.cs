using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Bilvaerksted.Models
{
    public class Job
    {
        //New
        [PrimaryKey,AutoIncrement]
        public int JobId { get; set; }
        public string? CustommerName { get; set; }
        public string? CustommerAdress { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Registration { get; set; }
        public DateTime Date { get; set; } 
        public string? Task { get; set; }   
    }
}
