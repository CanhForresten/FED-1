using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Bilvaerksted.Models
{
    public class Material
    {
        [PrimaryKey, AutoIncrement]
        public int MaterialId { get; set; }
        public int InvoiceId { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
    }
}