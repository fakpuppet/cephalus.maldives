namespace Cephalus.Maldives.Core.Models
{
    public class Country : Tag
    {
        public string Name { get; set; }

        public override string Display()
        {
            return Name;
        }
    }
}