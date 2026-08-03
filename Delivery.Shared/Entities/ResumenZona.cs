using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Shared.Entities
{
    public class ResumenZona
    {
        public string Zona { get; set; } = "";

        public int TotalPedidos { get; set; }

        public decimal TotalVentas { get; set; }
    }
}