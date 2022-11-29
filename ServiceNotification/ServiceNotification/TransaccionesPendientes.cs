using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceNotification
{
    public class Estado
    {
        public string estado { get; set; }
        public string cusPSE { get; set; }
        public string municipio { get; set; }
    }

    public class lisTransacciones
    {
        public List<Transaccion> transacciones { get; set; }
    }

    public class Transaccion
    {
        public Estado estado { get; set; }
        public string medioPago { get; set; }
        public string idTransaccion { get; set; }
    }

}
