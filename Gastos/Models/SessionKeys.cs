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
