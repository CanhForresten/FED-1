using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;


namespace Bilvaerksted.Models
{
    public partial class Invoice
    {
        [PrimaryKey, AutoIncrement]
        public int InvoiceId { get; set; }
        public int JobId { get; set; }
        public string? MechanicName { get; set; }   
        public int Hours { get; set; }
        public int HourPrice { get; set; }

        public decimal TotalPrice => (Hours * HourPrice) + (Materials?.Sum(m => m.Price) ?? 0);
        
        [Ignore]
        public ObservableCollection<Material>? Materials { get; set; }
    }
}
