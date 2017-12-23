using System.ComponentModel.DataAnnotations;

namespace Cephalus.Maldives.Core.Models
{
    public enum TagType
    {
        [Display(Name = "Generalic")]
        Generic = 0,
        Customer,
        Country,
        Activity,
        Ethnicity,
        Religion,
        Food,
        Beverage,
        WatchBrand,
    }
}
