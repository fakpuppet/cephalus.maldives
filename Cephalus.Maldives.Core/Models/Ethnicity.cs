namespace Cephalus.Maldives.Core.Models
{
    public class Ethnicity : Tag
    {
        public string Name { get; set; }

        public override string Display()
        {
            return Name;
        }
    }
}
