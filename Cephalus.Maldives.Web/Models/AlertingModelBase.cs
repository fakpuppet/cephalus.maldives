namespace Cephalus.Maldives.Web.Models
{
    public abstract class AlertingModelBase : IAlertingModel
    {
        public string Message { get; private set; }

        public AlertType AlertType { get; private set; }

        public void SetAlert(string message, AlertType alertType)
        {
            Message = message;
            AlertType = alertType;
        }
    }
}