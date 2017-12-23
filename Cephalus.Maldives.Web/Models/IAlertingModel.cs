namespace Cephalus.Maldives.Web.Models
{
    public interface IAlertingModel
    {
        void SetAlert(string message, AlertType alertType);
    }
}