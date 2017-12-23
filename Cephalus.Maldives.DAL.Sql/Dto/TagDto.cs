using System;
using System.ComponentModel.DataAnnotations;

namespace Cephalus.Maldives.DAL.Sql.Dto
{
    public abstract class TagDto
    {
        [Key]
        public int Id { get; set; }

        public Guid TagId { get; set; }

        public TagTypeDto TagType { get; set; }

        public string Name { get; set; }

        public CustomerDto Customer { get; set; }

        public abstract string Display();

        public virtual bool IsMatch (string keyWord)
        {
            return Name.Like(keyWord);
        }
    }
}