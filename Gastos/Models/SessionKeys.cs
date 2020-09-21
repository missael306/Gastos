using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gastos.Models
{
    public class SessionKeys
    {
        private static string AlertsKey = "lstAlertasTempData";
        public static string Alerts
        {
            get
            {
                return AlertsKey;
            }
        }
    }
}
