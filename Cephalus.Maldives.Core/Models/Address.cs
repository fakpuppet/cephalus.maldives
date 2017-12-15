namespace Cephalus.Maldives.Core.Models
{
    public class Address : Tag
    {
        public string Street { get; set; }

        public string Number { get; set; }

        public string City { get; set; }

        public Country Country { get; set; }

        public override string Display()
        {
            throw new System.NotImplementedException();
        }
    }
}
