using System.ComponentModel.DataAnnotations;

namespace Cephalus.Maldives.Core.Models
{
    public enum TagType
    {
        [Display(Name = "General")]
        Generic = 0,
        [Display(Name = "Customer")]
        Customer,
        [Display(Name = "Country")]
        Country,
        [Display(Name = "Activity")]
        Activity,
        [Display(Name = "Ethnicity")]
        Ethnicity,
        [Display(Name = "Religion")]
        Religion,
        [Display(Name = "Food")]
        Food,
        [Display(Name = "Beverage")]
        Beverage,
        [Display(Name = "Watch Brand")]
        WatchBrand,
    }
}
